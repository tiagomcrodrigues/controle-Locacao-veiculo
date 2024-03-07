using AutoFixture;
using dm = ControleLocacao.Domain.Entities;


namespace ControleLocacao.Test.Domain.Entities
{
    public class LocacaoTest
    {
        private Fixture _fixture = new Fixture();


        [Fact]
        public void ValidacaoLocacaoInvalidi()
        {
            var locacao = _fixture.Create<dm.Locacao>();
            locacao.Cliente.Id = 0;
            locacao.Veiculo.Id = 0;
            locacao.DiariasPrevistas = 0;
            locacao.Validate();
            Assert.False(locacao.IsValid);
            Assert.True(locacao.Notifications.Count() == 3);

        }


        [Fact]
        public void ValidacaoLocacaoInvalidi2()
        {
            var locacao = _fixture.Create<dm.Locacao>();
            locacao.DiariasRealizada = 0;

            locacao.Validate2();
            Assert.False(locacao.IsValid);
            Assert.True(locacao.Notifications.Count() == 1);

        }

    }
}
