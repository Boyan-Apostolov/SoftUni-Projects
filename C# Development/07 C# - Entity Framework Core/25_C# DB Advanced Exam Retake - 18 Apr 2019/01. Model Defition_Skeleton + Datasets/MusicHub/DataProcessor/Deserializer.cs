using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Internal;
using MusicHub.Data.Models;
using MusicHub.Data.Models.Enums;
using MusicHub.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var writers = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);
            var validWriters = new List<Writer>();

            foreach (var writerEto in writers)
            {
                if (!IsValid(writerEto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var writer = new Writer()
                {
                    Name = writerEto.Name,
                    Pseudonym = writerEto.Pseudonym
                };

                validWriters.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(validWriters);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var validProducers = new List<Producer>();

            var producersAndAlbums = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            foreach (var producer in producersAndAlbums)
            {
                bool errorOccured = false;

                var albums = new List<Album>();

                if (!IsValid(producer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (producer.Name.Length < 3)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var albumDto in producer.Albums)
                {
                    if (errorOccured)
                    {
                        continue;
                    }

                    DateTime albumReleaseDate;
                    bool isAlbumReleaseDateValid = DateTime.TryParseExact(albumDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out albumReleaseDate);

                    if (!isAlbumReleaseDateValid)
                    {
                        errorOccured = true;
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!IsValid(albumDto))
                    {
                        errorOccured = true;
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    albums.Add(new Album()
                    {
                        Name = albumDto.Name,
                        ReleaseDate = albumReleaseDate
                    });
                }

                if (errorOccured)
                {
                    continue;
                }

                var validProducer = new Producer()
                {
                    Name = producer.Name,
                    PhoneNumber = producer.PhoneNumber,
                    Albums = albums
                };
                validProducers.Add(validProducer);

                if (producer.PhoneNumber != null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, validProducer.Name,
                        validProducer.PhoneNumber, validProducer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, validProducer.Name, validProducer.Albums.Count));
                }
            }

            context.Producers.AddRange(validProducers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]), new XmlRootAttribute("Songs"));
            var songs = (ImportSongsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var validSongs = new List<Song>();

            foreach (var songDto in songs)
            {
                if (!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Albums.Any(s => s.Id == songDto.AlbumId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;
                if (!Enum.TryParse(songDto.Genre, true, out genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Writers.Any(s => s.Id == songDto.WriterId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan durationTimeSpan;
                bool isValidDucration = TimeSpan.TryParseExact(songDto.Duration, "c",
                CultureInfo.InvariantCulture, TimeSpanStyles.None, out durationTimeSpan);
                if (!isValidDucration)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime songCreationDate;
                bool isongCreationDateValid = DateTime.TryParseExact(songDto.CreatedOn, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out songCreationDate);

                if (!isongCreationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var song = new Song()
                {
                    Name = songDto.Name,
                    Duration = durationTimeSpan,
                    CreatedOn = songCreationDate,
                    Genre = (Genre)genre,
                    AlbumId = songDto.AlbumId == null ? null : songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };

                validSongs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, songDto.Name, songDto.Genre.ToString(),
                    durationTimeSpan));
            }

            context.Songs.AddRange(validSongs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var performersWithSongs = XmlConverter.Deserializer<ImportPerformerDto>(xmlString, "Performers");
            var validSongsPerformers = new List<Performer>();

            foreach (var performerDto in performersWithSongs)
            {
                bool errorOccured = false;
                if (!IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var performer = new Performer()
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth
                };
                var validSongs = new List<Song>();

                foreach (var songDto in performerDto.PerformedSongs)
                {
                    int id = int.Parse(songDto.Id);

                    var song = context.Songs.FirstOrDefault(s=>s.Id==id);
                    if (song == null)
                    {
                        errorOccured = true;
                        continue;
                    }//хммм
                    validSongs.Add(song);

                    var songPerformer = new SongPerformer()
                    {
                        Performer = performer,
                        Song = song
                    };

                    performer.PerformerSongs.Add(songPerformer);
                    
                }

                if (errorOccured)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                validSongsPerformers.Add(performer);
                var outputstr = string.Format(SuccessfullyImportedPerformer, performer.FirstName,
                    performer.PerformerSongs.Count);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName,
                    performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(validSongsPerformers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();
            var result = Validator.TryValidateObject(obj, validator, validationResult, true);
            return result;
        }

    }
}