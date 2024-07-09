using AutoMapper;
using GF.ControleAcesso.App.DTOs;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Enums;
using GF.ControleAcesso.Infra.CrossCutting.Helpers;

namespace GF.ControleAcesso.App.AutoMapper;

public class ConfigMapping : Profile
{
    public ConfigMapping()
    {
        CreateMap<UsuarioSignInDTO, Usuario>();
        CreateMap<Usuario, UsuarioDTO>()
            .ForMember(dto => dto.Perfil, opt => opt.MapFrom(u => ((EUsuarioPerfil)u.IdUsuarioPerfil).GetEnumDescription()))
            .ReverseMap();
    }
}
