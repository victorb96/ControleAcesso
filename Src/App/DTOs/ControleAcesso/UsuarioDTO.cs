namespace GF.ControleAcesso.App.DTOs.ControleAcesso;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int IdPerfil { get; set; }
    public string Perfil { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}

public class UsuarioCadastroDTO
{
    public string Nome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
    public int Numero { get; set; }
    public string Complemento { get; set; } = string.Empty;
    public int IdPerfil { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
}

public class UsuarioSenhaDTO
{
    public string Hash { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
