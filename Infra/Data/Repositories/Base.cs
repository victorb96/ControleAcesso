namespace GF.ControleAcesso.Infra.Data.Repositories;

public class Base
{
    public string GetConnectionString()
        => "Server=localhost;Database=controle_acesso;Port=8080;User Id=postgres;Password=^Z&yJLm=sbXnmQ[xhMtmPC&eNq7@Xou#;";
        //Environment.GetEnvironmentVariable("CONNECTION_STR_DB_CONTROLE_ACESSO");
}
