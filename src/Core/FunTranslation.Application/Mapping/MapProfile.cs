using AutoMapper;
using FunTranslation.Application.Dtos;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Language,LanguageCreateViewModel>().ReverseMap();
            CreateMap<Language,LanguageUpdateViewModel>().ReverseMap();
            CreateMap<PastText,TranslateViewModel>().ReverseMap();
            CreateMap<PastText,Contents>().ReverseMap();
        }
    }
}
