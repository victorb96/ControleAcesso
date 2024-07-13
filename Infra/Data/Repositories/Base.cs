namespace GF.ControleAcesso.Infra.Data.Repositories;

public class Base
{
    public string GetConnectionString()
        => //"Server=localhost;Database=controle_acesso;Port=5432;User Id=postgres;Password=^Z&yJLm=sbXnmQ[xhMtmPC&eNq7@Xou#;";
        $"Server={Environment.GetEnvironmentVariable("DB_HOST")};Database={Environment.GetEnvironmentVariable("DB_NAME")};Port={Environment.GetEnvironmentVariable("DB_PORT")};User Id={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PWD")};";
        //Environment.GetEnvironmentVariable("CONNECTION_STR_DB_CONTROLE_ACESSO");
}
