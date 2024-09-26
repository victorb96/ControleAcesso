using GF.ControleAcesso.Domain.Entities;

namespace GF.ControleAcesso.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Usuario? ObterPorEmail(string email);
    int Adicionar(Usuario usuario);
}
