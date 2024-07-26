namespace GF.ControleAcesso.Domain.Entities;

public class SignInResponse
{
    public Usuario Usuario { get; set; }
    public IEnumerable<MenuResponse> Menu { get; set; }
}

public class SubMenu : Base
{
    public string Nome { get; set; } = string.Empty;
    public string Icone { get; set; } = string.Empty;
    public string Rota { get; set; } = string.Empty;
    public int IdPai { get; set; }
}

public class MenuResponse : Base
{
    public string Nome { get; set; } = string.Empty;
    public string Icone { get; set; } = string.Empty;
    public IEnumerable<SubMenu> Menus{ get; set; }
}