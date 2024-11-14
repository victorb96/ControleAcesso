using GF.ControleAcesso.Domain.Entities;

namespace GF.ControleAcesso.Domain.Interfaces.Services;

public interface IUsuarioService
{
    Task<int> Adicionar(Usuario usuario);
    Task AdicionarSenha(Usuario usuario);
}
