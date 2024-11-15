using GF.ControleAcesso.Application.Validators;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using GF.ControleAcesso.Domain.Interfaces.Services;

namespace GF.ControleAcesso.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<int> Adicionar(Usuario usuario)
    {
        UsuarioValidation.ValidaUsuarioCadastro(usuario);
        return await _usuarioRepository.Adicionar(usuario);
    }

    public async Task AdicionarSenha(Usuario usuario)
    {
        UsuarioValidation.ValidaUsuarioCadastro(usuario);

        //return Task.FromResult(new { Teste = 1 });
    }
}
