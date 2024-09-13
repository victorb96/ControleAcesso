using Dapper;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using Npgsql;

namespace GF.ControleAcesso.Infra.Data.Repositories;

public class UsuarioRepository : Base, IUsuarioRepository
{
    private readonly string TABELA = "Usuario";
    private DynamicParameters parameters = new DynamicParameters();
    public Usuario? ObterPorEmailSenha(string email, string senha)
    {
        parameters.Add("@email", email);
        parameters.Add("@senha", senha);

        using (NpgsqlConnection connection = new NpgsqlConnection(GetConnectionString()))
        {
            string sql = $@"SELECT * FROM {TABELA} WHERE Email = @email AND Senha = @senha";
            return connection.Query<Usuario>(sql, parameters).FirstOrDefault();
        }
    }
}
