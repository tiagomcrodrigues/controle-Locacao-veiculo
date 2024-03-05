using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Categorias;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Categorias
{
    public class CategoriaAddUseCase  : UseCaseBase<ICategoriaService>, ICategoriaAddUseCase
    {

        public CategoriaAddUseCase(ICategoriaService categoriaService) : base(categoriaService) { }
        
        public IResult<int> Execute(CategoriaDto dto)
            => _service.Add(dto.Map());

    }
}
