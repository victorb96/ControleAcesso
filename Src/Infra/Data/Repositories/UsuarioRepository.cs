using Dapper;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using Npgsql;

namespace GF.ControleAcesso.Infra.Data.Repositories;

public class UsuarioRepository : Base, IUsuarioRepository
{
    private readonly string TABELA = "Usuario";
    private DynamicParameters parameters = new DynamicParameters();
    public async Task<Usuario?> ObterPorEmail(string email)
    {
        parameters.Add("@email", email);

        using (NpgsqlConnection connection = new NpgsqlConnection(GetConnectionString()))
        {
            string sql = $@"SELECT * FROM {TABELA} WHERE Email = @email LIMIT 1";
            return await connection.QueryFirstOrDefaultAsync<Usuario>(sql, parameters);
        }
    }

    public async Task<int> Adicionar(Usuario usuario)
    {
        parameters.Add("@Nome", usuario.Nome);
        parameters.Add("@Cpf", usuario.Cpf);
        parameters.Add("@Cep", usuario.Cep);
        parameters.Add("@Logradouro", usuario.Logradouro);
        parameters.Add("@Bairro", usuario.Bairro);
        parameters.Add("@Cidade", usuario.Cidade);
        parameters.Add("@UF", usuario.UF);
        parameters.Add("@Numero", usuario.Numero);
        parameters.Add("@Complemento", usuario.Complemento);
        parameters.Add("@IdPerfil", usuario.IdPerfil);
        parameters.Add("@Email", usuario.Email);
        parameters.Add("@Celular", usuario.Celular);

        using (NpgsqlConnection connection = new NpgsqlConnection(GetConnectionString()))
        {
            string sql = $@"
                            INSERT INTO {TABELA}(
                                DataCadastro,
                                Nome,
                                Cpf,
                                Cep,
                                Logradouro,
                                Bairro,
                                Cidade,
                                UF,
                                Numero,
                                Complemento,
                                IdPerfil,
                                Email,
                                Celular
                            ) VALUES(
                                NOW(),
                                @Nome,
                                @Cpf,
                                @Cep,
                                @Logradouro,
                                @Bairro,
                                @Cidade,
                                @UF,
                                @Numero,
                                @Complemento,
                                @IdPerfil,
                                @Email,
                                @Celular
                            )
                            RETURNING Id;";
                            
            return await connection.QueryFirstOrDefaultAsync<int>(sql, parameters);
        }
    }
}
