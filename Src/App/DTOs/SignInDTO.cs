namespace GF.ControleAcesso.App.DTOs;

public class SignInRequestDTO
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}

public class SignInResponseDTO
{
    public UsuarioDTO Usuario { get; set; }
    public string Token { get; set; } = string.Empty;
    public IEnumerable<MenuDTO> Menu{ get; set; }
}

public class SubMenuDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Icone { get; set; } = string.Empty;
    public string Rota { get; set; } = string.Empty;
    public int IdPai { get; set; }
}

public class MenuDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Icone { get; set; } = string.Empty;
    public IEnumerable<SubMenuDTO> Menus{ get; set; }
}