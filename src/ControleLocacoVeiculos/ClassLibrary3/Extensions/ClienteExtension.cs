using tb = ControleLocacao.Infra.Data.Tables;
using dm = ControleLocacao.Domain.Entities;


namespace ControleLocacao.Infra.Data.Extensions
{
    public static class ClienteExtension
    {

        public static tb.Cliente Map(this dm.Cliente entidade)
        {
            return new tb.Cliente()
            {
                Nome = entidade.Nome,
                TipoPessoa = entidade.TipoPessoa,
                Documento = entidade.Documento,
                Telefone = entidade.Telefone,
                Email = entidade.Email
            };
        }

        public static dm.Cliente Map(this tb.Cliente tabela)
            => new(tabela.Id)
            {
                Nome = tabela.Nome,
                TipoPessoa = tabela.TipoPessoa,
                Documento = tabela.Documento,
                Telefone = tabela.Telefone,
                Email = tabela.Email
            };

        public static tb.Cliente Map(this tb.Cliente tabela, dm.Cliente entidade)
        {
            tabela.Nome = entidade.Nome;
            tabela.TipoPessoa = entidade.TipoPessoa;
            tabela.Documento = entidade.Documento;
            tabela.Telefone = entidade.Telefone;
            tabela.Email = entidade.Email;

            return tabela;
        }


    }
}
