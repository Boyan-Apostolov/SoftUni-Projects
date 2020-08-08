using System.Globalization;
using System.Linq;
using MusicHub.DataProcessor.ExportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums.Where(a => a.ProducerId == producerId)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(y => new
                    {
                        SongName = y.Name,
                        Price = y.Price.ToString("f2"),
                        Writer = y.Writer.Name
                    })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToList(),
                    AlbumPrice = x.Price.ToString("f2")
                })
                .ToArray()
                .OrderByDescending(x => x.AlbumPrice)
                .ToArray();

            string json = JsonConvert.SerializeObject(albums, Formatting.Indented);
            return json;

        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.Where(x => x.Duration.TotalSeconds > duration)
                .ToArray()
                .Select(x => new ExportSongsWithInfoDto()
                {
                    SongName = x.Name,
                    Writer = x.Writer.Name,
                    Performer = x.SongPerformers.Select(y => y.Performer.FirstName + " " + y.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })
                .ToArray()
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToArray();

            string xml = XmlConverter.Serialize(songs, "Songs");
            return xml;
        }
    }
}