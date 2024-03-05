using ControleLocacao.Application.Dto;

namespace ControleLocacao.Application.Ports.Categorias
{
    public interface ICategoriaGetByIdUseCase
    {
        CategoriaDto? Execute(int id);
    }
}