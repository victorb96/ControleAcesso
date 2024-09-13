using System.ComponentModel;

namespace GF.ControleAcesso.Domain.Enums;

public enum EAcao
{
    [Description("Consultar")]
    Consultar = 1,
    [Description("Cadastrar")]
    Cadastrar = 2,
    [Description("Alterar")]
    Alterar = 3,
    [Description("Deletar")]
    Deletar = 4
}
