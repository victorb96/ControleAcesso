namespace GF.ControleAcesso.App.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public int IdUsuarioPerfil { get; set; }
    public string Perfil { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}

public class UsuarioSignInDTO
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
