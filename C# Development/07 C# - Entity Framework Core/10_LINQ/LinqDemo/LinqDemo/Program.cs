using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqDemo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Z.EntityFramework.Plus;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new MusicXContext();

            //var songs = dbContext.Songs
            //    .Where(x => x.Name.Contains("Survivor"))
            //    .OrderByDescending(x => x.Name)
            //    .ThenBy(x=>x.Id)
            //    .Select(x=>new SongsProjection{Name = x.Name})
            //    .ToList();

            //var songs = dbContext.Songs
            //    .Select(x => new
            //    {
            //        Name = x.Name,
            //        SourceName = x.Source.Name
            //    })
            //    .Where(x => x.SourceName == "User")
            //    .ToList();

            //var songs = dbContext.Songs
            //    .Where(x=>x.SongArtists.Count >2)
            //    .Select(x => new
            //    {
            //        Name = x.Name,
            //        Artists=x.SongArtists.Select(x=>x.Artist.Name)
            //    })
            //    .Take(10)
            //    .ToList();


            //foreach (var song in songs)
            //{
            //    Console.WriteLine(song.Name + " => " + string.Join(", ",song.Artists));
            //}

            //var songs = dbContext.Songs
            //.Where(x => x.SongArtists.Count > 2)
            //.Min(x=>x.Id) 
            //.Max(x=>x.Id)
            //.Average(x=>x.Id)
            //.Sum(x=>x.Id)
            //.ToList();

            //var songsCount = dbContext.Songs.Count(x => x.Name.Length > 5);
            //Console.WriteLine(songsCount);

            //var joinedSongsWithSourcesList = dbContext.Songs.Join(
            //    dbContext.Sources,
            //    songs => songs.SourceId,
            //    sources => sources.Id,
            //    (songs, sources) => new
            //    {
            //        SongName = songs.Name,
            //        SourceName = sources.Name
            //    }
            //).
            //    ToList();

            //SAME

            //var joinedSongsWithSourcesList = dbContext.Songs
            //    .Select(x => new
            //    {
            //        SongName = x.Name,
            //        SourceName = x.Source.Name
            //    })
            //    .ToList();

            //var songs = dbContext.Artists
            //        .Where(a => a.Name.StartsWith("Z"))
            //        .SelectMany(x=> x.SongArtists.Select(s => s.Song.Name))
            //        .ToList();
            //var songs = dbContext.Songs
            //    .Where(x => x.Name.Length > 20)
            //    .Select(x => x.Name)
            //    .ToList();

            //foreach (var song in songs)
            //{
            //    Console.WriteLine(song);
            //}

            // var searchString = Console.ReadLine(); //_bv%
            //var songs = dbContext.Songs
            //    .FromSqlRaw("SELECT * FROM [Songs] WHERE Name LIKE {0}",searchString)
            //    .ToList();

            // dbContext.Database.ExecuteSqlInterpolated($"DELETE {0}");

            //int isDeleted = 1;
            //dbContext.Database.ExecuteSqlInterpolated($"EXEC SetIsDeleted {isDeleted}");

            //var songs = dbContext.Songs
            //    .FirstOrDefault(x => x.Name == "Осъдени души");
            //songs.Name = "Осъдени души";
            //songs.ModifiedOn = DateTime.UtcNow;
            //dbContext.SaveChanges();

            ////NO UPDATE >>>>
            //var song = dbContext.Songs
            //    .Where(x => x.Name == "Осъдени души")
            //    .Select(x => new
            //    {
            //        x.Id,
            //        x.Name
            //    })
            //    .FirstOrDefault();

            //dbContext.SaveChanges();

            //dbContext.Entry(song).State = EntityState.Deleted;

            //var dbContextOther = new MusicXContext();
            //var song = dbContext.Songs
            //    .Where(x => x.Name == "Осъдени души")
            //    .FirstOrDefault();
            //song.Name = "Changed Name";
            ////Other Context so no save rip
            //dbContextOther.Entry(song).State = EntityState.Modified;
            //dbContextOther.SaveChanges();

            ////dbContext.SongMetadata.Where(x => x.SongId <= 10).Delete();
            //dbContext.Songs.Where(x => x.Name.Contains("а") || x.Name.Contains("е"))
            //    .Update(song => new Songs{ Name = song.Name+ "(BG)"});

            //var song = dbContext.Songs.Where(x => x.Name.StartsWith("Осъдени"))
            //    .Select(x=>new
            //    {
            //        x.Name,
            //        SourceName = x.Source.Name
            //    })
            //    .FirstOrDefault();
            //Console.WriteLine(song.Name);
            //Console.WriteLine(song.SourceName);


            //var song = dbContext.Songs.Where(x => x.Name.StartsWith("Осъдени"))
            //    .FirstOrDefault();
            ////Explicit Loading
            //dbContext.Entry(song).Reference(x => x.Source).Load();
            //dbContext.Entry(song).Collection(x => x.SongMetadata).Load();

            //Console.WriteLine(song.Name);
            //Console.WriteLine(song.Source.Name);

            //var song = dbContext.Songs
            //    .Include(x=>x.Source)
            //    .Include(x=>x.SongMetadata)
            //    .Include(x=>x.SongArtists)
            //    .ThenInclude(x=>x.Artist)
            //    .Where(x => x.Name.StartsWith("Осъдени"))
            //    .FirstOrDefault();

            //Console.WriteLine(song.Name);
            //Console.WriteLine(song.Source.Name);
            //Console.WriteLine(song.SongMetadata.Count

            //LAZY LOADING -> BAD
            //var songs = dbContext.Songs
            //    .Where(x => x.Name
            //        .Contains("а") || x.Name.Contains("е"))
            //    .ToList();

            //foreach (var song in songs)
            //{
            //    Console.WriteLine($"{song.Name} {song.Source.Name} {song.SongArtists.Count()}");
            //}

            //    var song = dbContext.Songs
            //        .Where(x => x.Name
            //            .Contains("а") || x.Name.Contains("е"))
            //        .FirstOrDefault();

            //    song.Name = song.Name + "1";

            //    var dbContext2 = new MusicXContext();

            //    dbContext.SaveChanges();

            //    try
            //    {
            //        dbContext2.SaveChanges();
            //    }
            //    catch (Exception e)
            //    {
            //        var dbcontext3 = new MusicXContext();
            //        var song2 = dbcontext3.Songs
            //            .Where(x => x.Name
            //                .Contains("а") || x.Name.Contains("е"))
            //            .FirstOrDefault();
            //        song.Name = song.Name + "2";
            //        dbcontext3.SaveChanges();
            //    }
            //var artists = dbContext.Artists.Select(x => new ArtistWithCount
            //{
            //    Name = x.Name,
            //    Count = x.SongArtists.Count
            //})
            //    .ToList();

            //    //PrintArtistAsJSON(artists);

            //    var config = new MapperConfiguration(cf =>
            //    {
            //        cf.CreateMap<Artists, ArtistWithCount>();

            //       cf.AddProfile(new SongsToViewModelProfile());
            //    });

            //    IMapper mapper = config.CreateMapper();
            //    //ArtistWithCount artistVIewModel = dbContext.Artists.ProjectTo<ArtistWithCount>(config).FirstOrDefault();
            //    //var artists = dbContext.Songs.ProjectTo<SongViewModel>(config).Take(10).ToList();

            //    //var song = dbContext.Songs.ProjectTo<SongViewModel>(config).Take(10).ToList();

            //    //Print(artists);

            //    var inputMode = new SongViewModel{Name = "Tests123",SourceName = "VBox7"};
            //    mapper.Map<SongViewModel, Songs>(inputMode);

            //}

            //public static void PrintCw(ArtistWithCount artist)
            //{
            //    Console.WriteLine($"{artist.Name} => {artist.Count}");
            //}

            //public static void Print(IEnumerable artists)
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(artists, Formatting.Indented));
            //}

            //JSON


        }

        class ArtistWithCount
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime? ModifiedOn { get; set; }
            public int SongArtistsCount { get; set; }
        }
    }
}


