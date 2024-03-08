using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Test.Domain.Entities
{
    public class CategoriaTest
    {

        [Fact]
        public void ValidacaoInvalidoCategoria()
        {
            var categoria = new Categoria();
            categoria.Validate();
            Assert.False(categoria.IsValid);
            Assert.True(categoria.Notifications.Count() == 3);
        }

        [Fact]
        public void ValidacaoPequenoCategoria()
        {
            var categoria = new Categoria() { Nome = "q", ValorDiaria = 0, ValorSeguro = 0 };
            categoria.Validate();
            Assert.False(categoria.IsValid);
            Assert.True(categoria.Notifications.Count() == 3);
        }
        [Fact]
        public void ValidacaoNomeGrandeCategoria()
        {
            var categoria = new Categoria(2) { Nome = new string('w', 110), ValorSeguro = 1, ValorDiaria = 1 };
            categoria.Validate();
            Assert.False(categoria.IsValid);
            Assert.True(categoria.Notifications.Count() == 1);
        }

    }
}
