using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.    Domain.Helpers;

namespace GF.ControleAcesso.Domain.Validators;

public static class UsuarioValidation
{
    public static void ValidaUsuarioSignIn(Usuario usuario)
    {
        string mensagemErro = "Email e/ou Senha inválidos";

        if(usuario == null)
            throw new Exception(mensagemErro);

        if(!usuario.Email.IsValidEmail())
            throw new Exception(mensagemErro);

        if(!usuario.Ativo)
            throw new Exception(mensagemErro);
    }

    public static void ValidaUsuarioCadastro(Usuario usuario)
    {
        if(usuario == null)
            throw new Exception("Dados do usuário inválidos");

        if(!usuario.Email.IsValidEmail())
            throw new Exception("Email inválido");

        //Colocar mais validacoes
    }
}
