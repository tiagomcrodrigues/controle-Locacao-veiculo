using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Categorias;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Ports;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Application.UseCases.Categorias
{
    public class CategoriaUpdateUseCase : UseCaseBase<ICategoriaService>, ICategoriaUpdateUseCase
    {
        public CategoriaUpdateUseCase(ICategoriaService service) : base(service)
        {
        }

        public IResult<bool> Execute(CategoriaDto dto)
            =>_service.Update(dto.Map());



    }
}
