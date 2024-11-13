using AutoMapper;
using GF.ControleAcesso.Application.DTOs;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GF.ControleAcesso.Presentation.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
[Route("[controller]")]
public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly IUsuarioService _usuarioService;
    private readonly IMapper _mapper;

    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService, IMapper mapper)
    {
        _logger = logger;
        _usuarioService = usuarioService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(UsuarioCadastroDTO request)
    {
        try
        {
            var idUsuario = _usuarioService.Adicionar(_mapper.Map<Usuario>(request));
            return Ok(new { Id = idUsuario });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }

    [HttpPost("cadastrar-senha")]
    public async Task<IActionResult> CadastrarSenha(UsuarioSenhaDTO request)
    {
        try
        {
            _usuarioService.AdicionarSenha(_mapper.Map<Usuario>(request));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}
