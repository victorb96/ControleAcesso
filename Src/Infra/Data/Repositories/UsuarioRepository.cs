using Dapper;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using Npgsql;

namespace GF.ControleAcesso.Infra.Data.Repositories;

public class UsuarioRepository : Base, IUsuarioRepository
{
    private readonly string TABELA = "Usuario";
    private DynamicParameters parameters = new DynamicParameters();
    public Usuario? ObterPorEmail(string email)
    {
        parameters.Add("@email", email);

        using (NpgsqlConnection connection = new NpgsqlConnection(GetConnectionString()))
        {
            string sql = $@"SELECT * FROM {TABELA} WHERE Email = @email LIMIT 1";
            return connection.Query<Usuario>(sql, parameters).FirstOrDefault();
        }
    }

    public int Adicionar(Usuario usuario)
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
        parameters.Add("@Ativo", usuario.Ativo);

        using (NpgsqlConnection connection = new NpgsqlConnection(GetConnectionString()))
        {
            string sql = $@"
                            INSERT INTO {TABELA}(
                                DataCadastro,
                                Ativo,
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
                                @Ativo,
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
                            
            return connection.Query<int>(sql, parameters).FirstOrDefault();
        }
    }
}
