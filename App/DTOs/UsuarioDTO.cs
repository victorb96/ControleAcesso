namespace GF.ControleAcesso.App.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int IdPerfil { get; set; }
    public string Perfil { get; set; } = string.Empty;
    public bool Ativo { get; set; }
}
