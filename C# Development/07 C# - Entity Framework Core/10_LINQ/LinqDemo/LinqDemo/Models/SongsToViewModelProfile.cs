using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace LinqDemo.Models
{
    class SongsToViewModelProfile : Profile
    {
        public SongsToViewModelProfile()
        {
            CreateMap<Songs, SongViewModel>()
                .ForMember(x =>
                        x.Artists,
                    options =>
                        options.MapFrom(s => string.Join(", ", s.SongArtists.Select(y => y.Artist.Name))))
                .ForMember(x => x.LastModivied, opt => opt.MapFrom(x =>
                    x.ModifiedOn))
                .ReverseMap();
        }
    }
}
