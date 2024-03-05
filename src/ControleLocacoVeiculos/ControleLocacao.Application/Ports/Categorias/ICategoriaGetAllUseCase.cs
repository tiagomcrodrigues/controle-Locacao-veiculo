using ControleLocacao.Application.Dto;

namespace ControleLocacao.Application.Ports.Categorias
{
    public interface ICategoriaGetAllUseCase
    {
        IEnumerable<CategoriaDto?> Execute();
    }
}