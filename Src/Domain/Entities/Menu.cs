namespace GF.ControleAcesso.Domain.Entities;

public class Menu : Base
{
    public string Nome { get; set; } = string.Empty;
    public string Icone { get; set; } = string.Empty;
    public string Rota { get; set; } = string.Empty;
    public int? IdPai { get; set; }
}
