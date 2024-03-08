using ControleLocacao.Application.Dto;
using ControleLocacao.Application.UseCases.Categorias;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;
using Moq;

namespace ControleLocacao.Test.Application.UseCases.Categorias
{
    public class CategoriaUpdateUseCaseTest : CategoriaUseCaseBaseTest<CategoriaUpdateUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {

            _service
                .Setup(p => p.Update(It.IsAny<Categoria>()))
                .Returns(new Result<bool>(true));

            var categoria = new CategoriaDto(ID_CATETORIA) { Nome = "CATEGORIA TEST" };
            var resut = _useCase.Execute(categoria);

            Assert.True(resut.Success);

        }
    }
}
