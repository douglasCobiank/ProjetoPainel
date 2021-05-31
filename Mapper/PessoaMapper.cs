using AutoMapper;
using ProjetoPainel.Models;
using RPA._000.RetornaCarteirasAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPainel.Mapper
{
    public class PessoaMapper : Profile
    {
        public PessoaMapper()
        {
            CreateMap<Rpa_pessoa, PessoaModel>()
                .ForMember(s => s.idPessoa, opt => opt.MapFrom(so => so.Id))
                .ForMember(s => s.nomePessoa, opt => opt.MapFrom(so => so.Nome))
                .ForMember(s => s.cargoPessoa, opt => opt.MapFrom(so => so.Cargo))
                ;

            CreateMap<PessoaModel, Rpa_pessoa>()
                .ForMember(s => s.Id, opt => opt.MapFrom(so => so.idPessoa))
                .ForMember(s => s.Nome, opt => opt.MapFrom(so => so.nomePessoa))
                .ForMember(s => s.Cargo, opt => opt.MapFrom(so => so.cargoPessoa))
                ;
        }
    }
}
