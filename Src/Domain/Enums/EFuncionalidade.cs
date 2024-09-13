using System.ComponentModel;

namespace GF.ControleAcesso.Domain.Enums;

public enum EFuncionalidade
{
    [Description("Usuário")]
    Usuario = 1,
    [Description("Produto")]
    Produto = 2,
    [Description("Serviço")]
    Servico = 3
}
