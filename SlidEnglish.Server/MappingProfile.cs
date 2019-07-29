using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlidEnglish.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile(SlidEnglishContext context)
        {
            CreateMap<Domain.Word, Shared.Word>()
              .ForMember(dest => dest.SynonymIds,
                    opt => opt.MapFrom(src => src.Synonyms.Select(x => x.Id)));
        }
    }
}
