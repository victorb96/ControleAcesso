using GF.ControleAcesso.Domain.Entities;

namespace GF.ControleAcesso.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Usuario? ObterPorEmailSenha(string email, string senha);
}
