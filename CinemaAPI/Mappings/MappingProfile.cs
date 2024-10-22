using AutoMapper;
using CinemaAPI.DTOs;
using CinemaAPI.Models;

namespace CinemaAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Filme, FilmeDTO>().ReverseMap();
            CreateMap<Sala, SalaDTO>().ReverseMap();
            CreateMap<Exibicao, ExibicaoDTO>().ReverseMap();
            CreateMap<Sessao, SessaoDTO>().ReverseMap();
        }
    }
}
