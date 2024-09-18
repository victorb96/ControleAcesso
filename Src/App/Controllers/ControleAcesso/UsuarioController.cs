using AutoMapper;
using GF.ControleAcesso.App.DTOs.ControleAcesso;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GF.ControleAcesso.App.Controllers.ControleAcesso;

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
    public IActionResult Adicionar(UsuarioCadastroDTO request)
    {
        try{
            var idUsuario = _usuarioService.Adicionar(_mapper.Map<Usuario>(request));
            return Ok(new { Id = idUsuario });
        }catch(Exception ex){
            return BadRequest(new {success = false, message = ex.Message});
        }
    }
}
