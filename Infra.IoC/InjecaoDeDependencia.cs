using Microsoft.Extensions.DependencyInjection;
using TestePratico.Application.Mapeamentos;
using TestePratico.Domain.Interfaces;
using TestePratico.Infra.Data.Repositories;

namespace TestePratico.Infra.IoC
{
    public static class InjecaoDeDependencia
    {
        public static IServiceCollection ConfigurarDI(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddAutoMapper(typeof(DominioParaViewModel));

            return services;
        }
    }
}
