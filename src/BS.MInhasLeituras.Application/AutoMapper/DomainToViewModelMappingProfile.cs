using AutoMapper;
using BS.MinhasLeituras.Domain.Entities;
using BS.MinhasLeituras.Application.ViewModels;

namespace BS.MinhasLeituras.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected  override void Configure()
        {
            Mapper.CreateMap<Leitura, LeituraViewModel>();
        }
    }
}
