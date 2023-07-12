using Microsoft.Extensions.DependencyInjection;
using Silogik.Business.Interfaces.Repositorio;
using Silogik.Core.Repositorio;

namespace Silogik.Infraesctructura.InjeccionDependencia
{
    public class InyeccionDependencia
    {
        public static void RegisterServices(IServiceCollection services)
        {

            #region Infraestructura

            services.AddScoped<IContactoRepositorio, ContactoRepositorio>();

            #endregion
        }
    }
}