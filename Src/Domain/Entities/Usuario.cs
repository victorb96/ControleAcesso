namespace GF.ControleAcesso.Domain.Entities;

public class Usuario : Base
{
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public DateTime? DataExclusao { get; set; }
    public bool Ativo { get; set; }
    public string Nome { get; set; } = string.Empty;
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
    public string Senha { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
}
