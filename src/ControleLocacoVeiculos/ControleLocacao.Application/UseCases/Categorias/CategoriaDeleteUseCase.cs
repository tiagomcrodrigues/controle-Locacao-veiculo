using ControleLocacao.Application.Ports.Categorias;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Categorias
{
    public class CategoriaDeleteUseCase : UseCaseBase<ICategoriaService>, ICategoriaDeleteUseCase
    {

        public CategoriaDeleteUseCase(ICategoriaService categoriaService) : base(categoriaService) { }


        public void Execute(int id)
            => _service.Delete(id);

    }
}
