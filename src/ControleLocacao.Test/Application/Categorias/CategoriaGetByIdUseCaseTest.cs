using AutoFixture;
using ControleLocacao.Application.UseCases.Categorias;
using ControleLocacao.Domain.Entities;
using Moq;

namespace ControleLocacao.Test.Application.UseCases.Categorias
{
    public class CategoriaGetByIdUseCaseTest : CategoriaUseCaseBaseTest<CategoriaGetByIdUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {
            Categoria Categoria = _fixture.Create<Categoria>();
            _service
                .Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(Categoria);

            var result = _useCase.Execute(ID_CATETORIA);

            Assert.NotNull(result);

        }
    }
}
