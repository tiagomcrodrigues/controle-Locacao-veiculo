using AutoFixture;
using ControleLocacao.Domain.Entities;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Domain.Services;
using Moq;

namespace ControleLocacao.Test.Domain.Services
{
    /* public class LocacacaoServiceTest
     {
         private Mock<ILocacaoRepository> _repositorio = new();
         private LocacaoService _locacaoService;
         private Fixture _fixture = new Fixture();
         private const int ID_Locacao = 1;


         public LocacaoServiceTest()
         {
             _locacaoService = new(_repositorio.Object);
         }

         private Locacao LocacaoCreate(int id)
             => _fixture.Build<Locacao>()
                 .FromFactory<int>((x) => new Locacao(id))
                 .Create();

         [Fact]
         public void AddSucess()
         {
             _repositorio
                 .Setup(p => p.Add(It.IsAny<Locacao>()))
                 .Returns(ID_Locacao);

             var locacao = _fixture.Create<Locacao>();
             locacao.Veiculo = new Veiculo(1) { Marca = "Veiculo TEST" };
             var result = _locacaoService.Add(locacao);

             Assert.True(result.Success);
             Assert.Equal(ID_Locacao, result.Data);
         }

         [Fact]
         public void AddError()
         {
             var locacao = new Locacao();
             var result = _locacaoService.Add(locacao);

             Assert.False(result.Success);
             Assert.Equal(4, result.Errors.Count());
         }



         [Fact]
         public void AddErrorDuplicate()
         {
             _repositorio
                 .Setup(p => p.Add(It.IsAny<Locacao>()))
                 .Throws(new Exception($"UK_{nameof(Locacao)}"));

             var locacao = _fixture.Create<Locacao>();
             locacao.Veiculo = new Veiculo(1) { Marca = "Veiculo TEST" };
             var result = _locacaoService.Add(locacao);

             Assert.False(result.Success);
             Assert.Single(result.Errors);
         }

         [Fact]
         public void AddErrorThor()
         {
             _repositorio
                 .Setup(p => p.Add(It.IsAny<Locacao>()))
                 .Throws(new Exception());

             var locacao = _fixture.Create<Locacao>();
             locacao.Veiculo = new Veiculo(1) { Marca = "Veiculo TEST" };

             Assert.Throws<Exception>(() => _locacaoService.Add(locacao));
         }

         [Fact]
         public void UpdateSucess()
         {
             _repositorio
                 .Setup(p => p.Update(It.IsAny<Locacao>()));

             var locacao = LocacaoCreate(ID_Locacao);

             locacao.Veiculo = new Veiculo(1) { Marca = "Veiculo TEST" };
             var result = _locacaoService.Update(locacao);

             Assert.True(result.Success);
         }

         [Fact]
         public void UpdateErrorThrow()
         {
             _repositorio
                 .Setup(p => p.Update(It.IsAny<Locacao>()))
                 .Throws(new Exception());

             var locacao = LocacaoCreate(ID_Locacao);

             locacao.Veiculo = new Veiculo(1) { Marca = "Veiculo TEST" };

             Assert.Throws<Exception>(() => _locacaoService.Update(locacao));
         }

         [Fact]
         public void UpdateError()
         {
             _repositorio
                 .Setup(p => p.Update(It.IsAny<Locacao>()))
                 .Throws(new Exception($"UK_{nameof(Locacao)}"));

             var locacao = _fixture.Create<Locacao>();
             locacao.Veiculo = new Veiculo(1) { Marca = "Veiculo TEST" };
             var result = _locacaoService.Update(locacao);

             Assert.False(result.Success);
             Assert.Single(result.Errors);
         }

         [Fact]
         public void GetAll()
         {
             IEnumerable<Locacao> locacaos = _fixture.Create<IEnumerable<Locacao>>();
             _repositorio
                .Setup(p => p.GetAll())
                .Returns(locacaos);
             var result = _locacaoService.GetAll();

             Assert.True(result.Any());
         }

         [Fact]
         public void GetIdOk()
         {
             Locacao locacao = LocacaoCreate(ID_Locacao);
             _repositorio
                 .Setup(p => p.GetById(It.IsAny<int>()))
                 .Returns(locacao);

             var result = _locacaoService.GetById(ID_Locacao);

             Assert.NotNull(result);

         }


     }
 

     */
}