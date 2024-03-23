using ControleLocacao.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using ControleLocacao.CrossCutting.IoC;
using FluentValidation.AspNetCore;
using ControleLocacao.Api.Extensions;
using System.Reflection;
using FluentValidation;
using Serilog;
using ControleLocacao.Api.Models.Middleware;

namespace ControleLocacao.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, loggerConfig) =>
                loggerConfig.ReadFrom.Configuration(context.Configuration));


            // Add services to the container.

            builder.Services.AddControllers(opt => GlobalFilters.Configure(opt));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Essa bagaça é para desabilitar o auto validate model filter
            builder.Services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.RegistraServicos(builder.Configuration.GetConnectionString("Db"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseMiddleware<RequestResponseLoggerMiddleware>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
