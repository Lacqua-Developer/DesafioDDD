using Catalogo.Domain.Entities.Modules.Produtos;
using Catalogo.Domain.Interfaces;
using Catalogo.Domain.Interfaces.IRepositories;
using Catalogo.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Ioc
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddCatalogoInfra<T>(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IRepositories<>), typeof(Repository<>));

            //services.AddTransient<IGraficoUseCase, UseCases.GraficoUseCase>();
            return services;
        }

        public static IServiceCollection AddCatalogoUseCases(this IServiceCollection services)
        {
           
            services.AddTransient(typeof(IApp<>) , typeof(Repository<>));
            return services;
        }
    }
}
