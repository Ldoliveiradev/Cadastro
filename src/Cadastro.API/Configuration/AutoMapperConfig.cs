using AutoMapper;
using Cadastro.API.Models.Dtos;
using Cadastro.Domain.Models;

namespace Cadastro.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PessoaDto, Pessoa>().ForPath(d => d.Cidade.Nome, o => o.MapFrom(x => x.NomeCidade))
                .ForPath(d => d.Cidade.Uf, o => o.MapFrom(x => x.Uf)).ReverseMap();
        }
    }
}
