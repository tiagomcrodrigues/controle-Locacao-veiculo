using ControleLocacao.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Infra.Data.Repositories;
using ControleLocacao.Domain.Services;
using ControleLocacao.Application.Ports.Categorias;
using ControleLocacao.Application.UseCases.Categorias;
using ControleLocacao.CrossCutting.Common.Abstractions;

namespace ControleLocacao.CrossCutting.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegistraServicos(this IServiceCollection service, string connectionString)
        {

            service.AddDbContext<DbLocacao>(opt =>
            {
                //proxies bamco
                opt.UseLazyLoadingProxies();
                //
                opt.UseMySql
                (
                    connectionString,
                    ServerVersion.AutoDetect(connectionString)
                );
            });
            service.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositórios
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();


            // Serviços de Domínio
            service.AddScoped<ICategoriaService, CategoriaService>();


            // Casos de Uso
            service.AddScoped<ICategoriaAddUseCase, CategoriaAddUseCase>();
            service.AddScoped<ICategoriaGetByIdUseCase, CategoriaGetByIdUseCase>();
            service.AddScoped<ICategoriaGetAllUseCase, CategoriaGetAllUseCase>();
            service.AddScoped<ICategoriaUpdateUseCase, CategoriaUpdateUseCase>();
            service.AddScoped<ICategoriaDeleteUseCase, CategoriaDeleteUseCase>();


            return service;

        }

    }
}
