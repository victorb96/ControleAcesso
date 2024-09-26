using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using GF.ControleAcesso.Domain.Interfaces.Services;
using GF.ControleAcesso.Domain.Validators;

namespace GF.ControleAcesso.Domain.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public int Adicionar(Usuario usuario)
    {
        UsuarioValidation.ValidaUsuarioCadastro(usuario);
        return _usuarioRepository.Adicionar(usuario);
    }

    public void AdicionarSenha(Usuario usuario)
    {
        UsuarioValidation.ValidaUsuarioCadastro(usuario);
    }
}
