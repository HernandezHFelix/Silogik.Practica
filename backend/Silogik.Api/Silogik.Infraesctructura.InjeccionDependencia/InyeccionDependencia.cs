using Microsoft.Extensions.DependencyInjection;
using Silogik.Domain.Interfaces.Repositorio;
using Silogik.Core.Repositorio;
using Silogik.Infraestructura.Data.Repositorio;

namespace Silogik.Infraesctructura.InjeccionDependencia
{
    public class InyeccionDependencia
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Infraestructura

            services.AddScoped<IContactoRepositorio, ContactoRepositorio>();
            services.AddScoped<ITraductorRepositorio, TraductorRepositorio>();

            #endregion
        }
    }
}