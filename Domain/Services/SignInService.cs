using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using GF.ControleAcesso.Domain.Interfaces.Services;

namespace GF.ControleAcesso.Domain.Services;

public class SignInService : ISignInService
{
    private readonly IUsuarioRepository _iUsuarioRepository;

    public SignInService(IUsuarioRepository iUsuarioRepository)
    {
        _iUsuarioRepository = iUsuarioRepository;
    }

    public Usuario SignIn(Usuario request)
    {
        return _iUsuarioRepository.ObterPorEmailSenha(request.Email, request.Senha);
    }
}
