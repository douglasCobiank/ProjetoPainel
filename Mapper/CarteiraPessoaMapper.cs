using AutoMapper;
using RPA._000.RetornaCarteirasAPI.Models;
using RPA._000.RetornaCarteirasAPI.Models.Entities;

namespace ProjetoPainel.Mapper
{
    public class CarteiraPessoaMapper : Profile
    {
        public CarteiraPessoaMapper()
        {
            CreateMap<Rpa_carteirapessoa, CarteiraModel>()
                .ForMember(s => s.idbp, opt => opt.MapFrom(so => so.BP.Id))
                .ForMember(s => s.bp, opt => opt.MapFrom(so => so.BP.Nome))
                .ForMember(s => s.idcoordenador, opt => opt.MapFrom(so => so.Coordenador.Id))
                .ForMember(s => s.coordenador, opt => opt.MapFrom(so => so.Coordenador.Nome))
                .ForMember(s => s.idexecutivo, opt => opt.MapFrom(so => so.Executivo.Id))
                .ForMember(s => s.executivo, opt => opt.MapFrom(so => so.Executivo.Nome))
                .ForMember(s => s.idprogramador, opt => opt.MapFrom(so => so.Programador.Id))
                .ForMember(s => s.programador, opt => opt.MapFrom(so => so.Programador.Nome))
                .ForMember(s => s.idsuper, opt => opt.MapFrom(so => so.Super.Id))
                .ForMember(s => s.super, opt => opt.MapFrom(so => so.Super.Nome))
                ;
        }
    }
}
