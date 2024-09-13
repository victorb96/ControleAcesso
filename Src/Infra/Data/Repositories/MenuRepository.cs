using Dapper;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Enums;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using Npgsql;

namespace GF.ControleAcesso.Infra.Data.Repositories;

public class MenuRepository : Base, IMenuRepository
{
    private readonly string TABELA = "Menu";
    private DynamicParameters parameters = new DynamicParameters();
    public IEnumerable<Menu> ObterMenusUsuario(int idUsuario)
    {
        parameters.Add("@idUsuario", idUsuario);
        parameters.Add("@idAcaoConsultar", (int)EAcao.Consultar);

        using (var connection = new NpgsqlConnection(GetConnectionString()))
        {
            var sql = $@"
            SELECT DISTINCT * 
                FROM {TABELA}
                WHERE Id IN(
                SELECT f.IdMenu 
                    FROM Funcionalidade f
                    JOIN UsuarioFuncionalidadeAcao ufa ON ufa.idfuncionalidade = f.id
                    WHERE ufa.idusuario = @idUsuario AND ufa.idacao = @idAcaoConsultar
                
                UNION
                
                SELECT DISTINCT IdPai AS IdMenu
                FROM {TABELA}
                WHERE Id IN(
                    SELECT f.IdMenu 
                    FROM Funcionalidade f
                    JOIN UsuarioFuncionalidadeAcao ufa ON ufa.idfuncionalidade = f.id
                    WHERE ufa.idusuario = @idUsuario AND ufa.idacao = @idAcaoConsultar
                )
            )
            ORDER BY Id
            ";

            return connection.Query<Menu>(sql, parameters);
        }
    }
}
