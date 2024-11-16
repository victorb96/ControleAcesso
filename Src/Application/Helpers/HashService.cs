namespace GF.ControleAcesso.Application.Helpers;

public static class HashService
{
    public static string GerarHashSenha(string senha)
        => BCrypt.Net.BCrypt.HashPassword(senha, BCrypt.Net.BCrypt.GenerateSalt(12));

    public static bool SenhaValida(string senha, string hash) => BCrypt.Net.BCrypt.Verify(senha, hash);
}
