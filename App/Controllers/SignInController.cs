using AutoMapper;
using GF.ControleAcesso.App.DTOs;
using GF.ControleAcesso.Domain.Entities;
using GF.ControleAcesso.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GF.ControleAcesso.App.Controllers;

[ApiController]
[Route("[controller]")]
public class SignInController : ControllerBase
{
    private readonly ILogger<SignInController> _logger;
    private readonly IMapper _mapper;
    private readonly ISignInService _signInService;

    public SignInController(ILogger<SignInController> logger, IMapper mapper, ISignInService signInService)
    {
        _logger = logger;
        _mapper = mapper;
        _signInService = signInService;
    }

    [HttpPost]
    public IActionResult SignIn(UsuarioSignInDTO request)
    {
        var response = _mapper.Map<UsuarioDTO>(_signInService.SignIn(_mapper.Map<Usuario>(request)));
        return Ok(response);
    }
}
