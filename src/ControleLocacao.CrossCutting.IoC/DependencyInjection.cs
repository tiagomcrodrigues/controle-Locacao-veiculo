using ControleLocacao.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Infra.Data.Repositories;
using ControleLocacao.Domain.Services;
using ControleLocacao.Application.Ports.Categorias;
using ControleLocacao.Application.UseCases.Categorias;
using ControleLocacao.CrossCutting.Common.Abstractions;
using ControleLocacao.Application.Ports.Clientes;
using ControleLocacao.Application.UseCases.Clientes;

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
            service.AddScoped<IClienteRepository, ClienteRepository>();


            // Serviços de Domínio
            service.AddScoped<ICategoriaService, CategoriaService>();
            service.AddScoped<IClienteService, ClienteService>();

            // Casos de Uso
            service.AddScoped<ICategoriaAddUseCase, CategoriaAddUseCase>();
            service.AddScoped<ICategoriaGetByIdUseCase, CategoriaGetByIdUseCase>();
            service.AddScoped<ICategoriaGetAllUseCase, CategoriaGetAllUseCase>();
            service.AddScoped<ICategoriaUpdateUseCase, CategoriaUpdateUseCase>();
            service.AddScoped<ICategoriaDeleteUseCase, CategoriaDeleteUseCase>();

            service.AddScoped<IClienteAddUseCase, ClienteAddUseCase>();
            service.AddScoped<IClienteGetByIdUseCase, ClienteGetByIdUseCase>();
            service.AddScoped<IClienteGetAllUseCase, ClienteGetAllUseCase>();
            service.AddScoped<IClienteUpdateUseCase, ClienteUpdateUseCase>();
            service.AddScoped<IClienteDeleteUseCase, ClienteDeleteUseCase>();

            return service;

        }

    }
}
