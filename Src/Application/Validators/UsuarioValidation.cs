using FluentValidation;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Enums;

namespace GF.ControleAcesso.Application.Validators;

public class UsuarioValidation : AbstractValidator<Usuario>
{
    public UsuarioValidation()
    {
        RuleFor(usuario => usuario.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(200)
            .WithMessage("Email e/ou Senha inválidos");
    }
}

public class UsuarioCadastroValidation : AbstractValidator<Usuario>
{
    public UsuarioCadastroValidation()
    {
        RuleFor(u => u.Nome)
            .NotNull()
            .NotEmpty()
            .MaximumLength(60)
            .WithMessage("Nome inválido");
        RuleFor(u => u.Cpf)
            .NotEmpty()
            .NotEmpty()
            .MinimumLength(11)
            .MaximumLength(11)
            .WithMessage("CPF inválido");
        RuleFor(u => u.Cep)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(8)
            .WithMessage("CEP inválido");
        RuleFor(u => u.Logradouro)
            .NotNull()
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(200)
            .WithMessage("Endereço inválido");
        RuleFor(u => u.Bairro)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(200)
            .WithMessage("Bairro inválido");
        RuleFor(u => u.Cidade)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(200)
            .WithMessage("Cidade inválido");
        RuleFor(u => u.UF)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(2)
            .Must(uf => new List<string>
            {
                "AC",
                "AL",
                "AP",
                "AM",
                "BA",
                "CE",
                "DF",
                "ES",
                "GO",
                "MA",
                "MT",
                "MS",
                "MG",
                "PA",
                "PB",
                "PR",
                "PE",
                "PI",
                "RJ",
                "RN",
                "RS",
                "RO",
                "RR",
                "SC",
                "SP",
                "SE",
                "TO",
            }.Contains(uf))
            .WithMessage("UF inválido");
        RuleFor(u => u.Numero)
            .NotNull()
            .NotEmpty()
            .WithMessage("Número inválido");
        RuleFor(u => u.IdPerfil)
            .NotNull()
            .NotEmpty()
            .Must(id => new List<int>
            {
                (int)EPerfil.Administrador,
                (int)EPerfil.Operador,
                (int)EPerfil.Tecnico
            }.Contains(id))
            .WithMessage("Perfil inválido");
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(200)
            .WithMessage("Email e/ou Senha inválidos");
        RuleFor(u => u.Celular)
            .MaximumLength(11)
            .WithMessage("Celular inválido");
    }
}

public class UsuarioSigninValidation : AbstractValidator<Usuario>
{
    public UsuarioSigninValidation()
    {
        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(200)
            .WithMessage("Email e/ou Senha inválidos");
        RuleFor(u => u.Senha)
            .NotNull()
            .NotEmpty()
            //.MinimumLength(8)
            .MaximumLength(150)
            //.Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,150}$")
            .WithMessage("Email e/ou Senha inválidos");
    }
}
