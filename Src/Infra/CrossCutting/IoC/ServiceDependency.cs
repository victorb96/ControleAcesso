using GF.ControleAcesso.Domain.Interfaces.Repositories;
using GF.ControleAcesso.Domain.Interfaces.Services;
using GF.ControleAcesso.Domain.Services;
using GF.ControleAcesso.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GF.ControleAcesso.Infra.CrossCutting.IoC;

public class ServiceDependency
{
    public static void AddServiceDependency(IServiceCollection services)
    {
        services.AddScoped<ISignInService, SignInService> ();
        services.AddScoped<IUsuarioService, UsuarioService> ();

        services.AddScoped<IUsuarioRepository, UsuarioRepository> ();
        services.AddScoped<IMenuRepository, MenuRepository> ();
    }
}
