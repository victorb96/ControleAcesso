using GF.ControleAcesso.Domain.Entities;

namespace GF.ControleAcesso.Domain.Interfaces.Repositories;

public interface IMenuRepository
{
    IEnumerable<Menu> ObterMenusUsuario(int idUsuario);
}