using GF.ControleAcesso.Domain.Entities;

namespace GF.ControleAcesso.Domain.Interfaces.Services;

public interface IUsuarioService
{
    int Adicionar(Usuario usuario);
    void AdicionarSenha(Usuario usuario);
}
