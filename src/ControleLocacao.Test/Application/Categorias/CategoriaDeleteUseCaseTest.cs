using ControleLocacao.Application.UseCases.Categorias;

namespace ControleLocacao.Test.Application.UseCases.Categorias
{
    public class CategoriaDeleteUseCaseTest : CategoriaUseCaseBaseTest<CategoriaDeleteUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {
            _useCase.Execute(ID_CATETORIA);

        }
    }
}
