using Application.Functions.Worksites.Commands.CreateWorksite;
using AutoMapper;
using Domain.Models.DictionaryModels;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Worksite, CreateWorksiteCommand>().ReverseMap();
        }
    }
}
