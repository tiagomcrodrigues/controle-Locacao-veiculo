using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Application.Ports.Categorias
{
    public interface ICategoriaAddUseCase
    {
        IResult<int> Execute(CategoriaDto dto);
    }
}
