using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using GF.ControleAcesso.Domain.Interfaces.Services;
using GF.ControleAcesso.Domain.Validators;

namespace GF.ControleAcesso.Domain.Services;

public class SignInService : ISignInService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMenuRepository _menuRepository;

    public SignInService(IUsuarioRepository usuarioRepository, IMenuRepository menuRepository)
    {
        _usuarioRepository = usuarioRepository;
        _menuRepository = menuRepository;
    }

    public SignInResponse SignIn(Usuario request)
    {
        var usuario = _usuarioRepository.ObterPorEmailSenha(request.Email, request.Senha);

        UsuarioValidation.ValidaUsuarioSignIn(usuario);

        var menu = _menuRepository.ObterMenusUsuario(usuario.Id);

        return new SignInResponse
        {
            Usuario = usuario,
            Menu = menu.Where(m => !m.IdPai.HasValue).Select(m => new MenuResponse
            {
                Id = m.Id,
                Icone = m.Icone,
                Nome = m.Nome,
                Menus = menu.Where(sm => sm.IdPai.HasValue && sm.IdPai.Value == m.Id).Select(sm => new SubMenu
                {
                    Id = sm.Id,
                    Icone = sm.Icone,
                    Nome = sm.Nome,
                    IdPai = sm.IdPai ?? 0,
                    Rota = sm.Rota
                }).ToList()
            }).ToList()
        };
    }
}
