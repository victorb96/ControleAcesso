using AutoMapper;
using GF.ControleAcesso.Application.DTOs;
using GF.ControleAcesso.Application.Helpers;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Enums;

namespace GF.ControleAcesso.Application.AutoMapper;

public class ConfigMapping : Profile
{
    public ConfigMapping()
    {
        CreateMap<SignInRequestDTO, Usuario>();
        CreateMap<MenuResponse, MenuDTO>();
        CreateMap<SubMenu, SubMenuDTO>();
        CreateMap<Usuario, UsuarioDTO>()
            .ForMember(dto => dto.Perfil, opt => opt.MapFrom(e => ((EPerfil)e.IdPerfil).GetEnumDescription()));
        CreateMap<SignInResponse, SignInResponseDTO>()
            .ForMember(dto => dto.Token, opt => opt.MapFrom(e => TokenService.GerarToken(e.Usuario)));
        CreateMap<UsuarioCadastroDTO, Usuario>();
    }
}
