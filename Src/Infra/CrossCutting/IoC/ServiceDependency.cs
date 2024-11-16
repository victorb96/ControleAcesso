using GF.ControleAcesso.Application.Services;
using GF.ControleAcesso.Domain.Interfaces.Repositories;
using GF.ControleAcesso.Domain.Interfaces.Services;
using GF.ControleAcesso.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GF.ControleAcesso.Infra.CrossCutting.IoC;

public class ServiceDependency
{
    public static void AddServiceDependency(IServiceCollection services)
    {
        #region Services
        services.AddScoped<ISignInService, SignInService> ();
        services.AddScoped<IUsuarioService, UsuarioService> ();
        #endregion
        
        #region Validators
        #endregion

        #region Repositories
        services.AddScoped<IUsuarioRepository, UsuarioRepository> ();
        services.AddScoped<IMenuRepository, MenuRepository> ();
        #endregion
    }
}
