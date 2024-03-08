using AutoFixture;
using ControleLocacao.Application.UseCases.Categorias;
using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Test.Application.UseCases.Categorias
{
    public class CategoriaGetAllUseCaseTest : CategoriaUseCaseBaseTest<CategoriaGetAllUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }
        [Fact]
        public void ExecuteOk()
        {
            IEnumerable<Categoria> dto = _fixture.Create<IEnumerable<Categoria>>();
            _service
                .Setup(p => p.GetAll())
                .Returns(dto);

            var result = _useCase.Execute();

            Assert.True(result.Any());

        }
    }
}
