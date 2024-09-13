using System.ComponentModel;

namespace GF.ControleAcesso.Domain.Enums;
public enum EPerfil
{
    [Description("Administrador")]
    Administrador = 1,
    [Description("Operador")]
    Operador = 2,
    [Description("Técnico")]
    Tecnico = 3
}
