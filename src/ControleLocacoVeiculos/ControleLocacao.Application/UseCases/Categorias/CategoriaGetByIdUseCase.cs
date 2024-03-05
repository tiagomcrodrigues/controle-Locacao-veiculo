using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Categorias;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Categorias
{
    public class CategoriaGetByIdUseCase : UseCaseBase<ICategoriaService>, ICategoriaGetByIdUseCase
    {
        public CategoriaGetByIdUseCase(ICategoriaService service) : base(service)
        {
        }

        public CategoriaDto? Execute(int id)
            => _service.GetById(id).Map();


    }
}
