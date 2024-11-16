using GF.ControleAcesso.Domain.Entities;

namespace GF.ControleAcesso.Domain.Interfaces.Services;

public interface ISignInService
{
    Task<SignInResponse> SignIn(Usuario request);
}
