using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Categorias;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Categorias
{
    public class CategoriaGetAllUseCase : UseCaseBase<ICategoriaService>, ICategoriaGetAllUseCase
    {
        public CategoriaGetAllUseCase(ICategoriaService service) : base(service) { }

        public IEnumerable<CategoriaDto?> Execute()
            => _service.GetAll().Select(s => s.Map());


    }
}
