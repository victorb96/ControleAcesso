using FluentValidation;
using GF.ControleAcesso.Application.Helpers;
using GF.ControleAcesso.Domain.Entities;

namespace GF.ControleAcesso.Application.Validators;

public class SignInValidation : AbstractValidator<Usuario>
{
    public SignInValidation(string senhaReq)
    {
        RuleFor(usuario => usuario.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(200)
            .WithMessage("Email e/ou Senha inválidos");
        RuleFor(usuario => usuario.Senha)
            .NotNull()
            .NotEmpty()
            .MaximumLength(150)
            .MinimumLength(8)
            .Must(senha => HashService.SenhaValida(senhaReq, senha))
            .WithMessage("Email e/ou Senha inválidos");
        RuleFor(usuario => usuario.Ativo)
            .NotNull()
            .NotEmpty()
            .Must(ativo => ativo == true)
            .WithMessage("Email e/ou Senha inválidos");
    }
}