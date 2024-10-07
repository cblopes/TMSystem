using TMS.Business.Interfaces;
using TMS.Business.Notificacoes;
using TMS.Business.Services;
using TMS.Data.Context;
using TMS.Data.Repositories;

namespace TMS.Api.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        // Data
        services.AddScoped<AppDbContext>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();

        // Business
        services.AddScoped<INotificador, Notificador>();
        services.AddScoped<IPedidoService, PedidoService>();
        services.AddScoped<IOcorrenciaService, OcorrenciaService>();

        return services;
    }
}
