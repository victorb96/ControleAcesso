namespace GF.ControleAcesso.Infra.Data.Repositories;

public class Base
{
    public string GetConnectionString()
        => $"Server={Environment.GetEnvironmentVariable("DB_HOST")};Database={Environment.GetEnvironmentVariable("DB_NAME")};Port={Environment.GetEnvironmentVariable("DB_PORT")};User Id={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PWD")};";
}
