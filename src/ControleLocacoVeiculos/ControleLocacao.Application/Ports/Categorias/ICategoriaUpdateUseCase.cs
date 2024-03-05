using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Ports.Categorias
{
    public interface ICategoriaUpdateUseCase
    {
        IResult<bool> Execute(CategoriaDto dto);
    }
}