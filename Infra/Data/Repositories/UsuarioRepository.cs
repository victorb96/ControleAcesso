using Dapper;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using Npgsql;

namespace GF.ControleAcesso.Infra.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly string TABELA = "Usuario";
    private DynamicParameters parameters = new DynamicParameters();
    public Usuario? ObterPorEmailSenha(string email, string senha)
    {
        parameters.Add("@email", email);
        parameters.Add("@senha", senha);

        using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Database=controle_acesso;Port=8080;User Id=postgres;Password=^Z&yJLm=sbXnmQ[xhMtmPC&eNq7@Xou#;"))
        {
            string sql = $@"SELECT * FROM {TABELA} WHERE Email = @email AND Senha = @senha";
            return connection.Query<Usuario>(sql, parameters).FirstOrDefault();
        }
    }
}
