using GF.ControleAcesso.Application.Validators;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using GF.ControleAcesso.Domain.Interfaces.Services;

namespace GF.ControleAcesso.Application.Services;

public class SignInService : ISignInService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMenuRepository _menuRepository;

    public SignInService(IUsuarioRepository usuarioRepository, IMenuRepository menuRepository)
    {
        _usuarioRepository = usuarioRepository;
        _menuRepository = menuRepository;
    }

    public async Task<SignInResponse> SignIn(Usuario request)
    {
        var usuario = await _usuarioRepository.ObterPorEmail(request.Email);

        if (usuario == null)
            throw new Exception("Email e/ou Senha inválidos");
        
        var validatorResult = new SignInValidation(request.Senha).Validate(usuario);
        if (!validatorResult.IsValid)
            throw new Exception(validatorResult.ToString());

        var menu = await _menuRepository.ObterMenusUsuario(usuario.Id);

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
