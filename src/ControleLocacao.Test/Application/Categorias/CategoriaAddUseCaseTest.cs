using AutoFixture;
using ControleLocacao.Application.Dto;
using ControleLocacao.Application.UseCases.Categorias;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;
using Moq;

namespace ControleLocacao.Test.Application.UseCases.Categorias
{
    public class CategoriaAddUseCaseTest : CategoriaUseCaseBaseTest<CategoriaAddUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {
            _service
                .Setup(p => p.Add(It.IsAny<Categoria>()))
                .Returns(new Result<int>(ID_CATETORIA));

            var dto = _fixture.Create<CategoriaDto>();
            var result = _useCase.Execute(dto);

            Assert.True(result.Success);
            Assert.Equal(ID_CATETORIA, result.Data);

        }

       
    }
}
