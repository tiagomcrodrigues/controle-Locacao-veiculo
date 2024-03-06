using tb = ControleLocacao.Infra.Data.Tables;
using dm = ControleLocacao.Domain.Entities;

namespace ControleLocacao.Infra.Data.Extensions
{
    public static class CategoriaExtension
    {
        public static tb.Categoria Map(this dm.Categoria entidade)
        {
            return new tb.Categoria()
            {
                Nome = entidade.Nome,
                ValorDiaria = entidade.ValorDiaria,
                ValorSeguro = entidade.ValorSeguro
            };
        }

        public static dm.Categoria Map(this tb.Categoria tabela)
            => new(tabela.Id)
            {
                Nome = tabela.Nome,
                ValorDiaria = tabela.ValorDiaria,
                ValorSeguro = tabela.ValorSeguro
            };

        public static tb.Categoria Map(this tb.Categoria tabela, dm.Categoria entidade)
        {
            //tabela.Id = entidade.Id;
            tabela.Nome = entidade.Nome;
            tabela.ValorDiaria = entidade.ValorDiaria;
            tabela.ValorSeguro = entidade.ValorSeguro;
            return tabela;
        }

    }

}
