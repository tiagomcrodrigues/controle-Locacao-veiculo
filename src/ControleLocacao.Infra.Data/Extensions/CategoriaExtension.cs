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
                valorDiaria = entidade.valorDiaria,
                valorSeguro = entidade.valorSeguro
            };
        }

        public static dm.Categoria Map(this tb.Categoria tabela)
            => new(tabela.Id)
            {
                Nome = tabela.Nome,
                valorDiaria = tabela.valorDiaria,
                valorSeguro = tabela.valorSeguro
            };

        public static tb.Categoria Map(this tb.Categoria tabela, dm.Categoria entidade)
        {
            //tabela.Id = entidade.Id;
            tabela.Nome = entidade.Nome;
            tabela.valorDiaria = entidade.valorDiaria;
            tabela.valorSeguro = entidade.valorSeguro;
            return tabela;
        }

    }

}
