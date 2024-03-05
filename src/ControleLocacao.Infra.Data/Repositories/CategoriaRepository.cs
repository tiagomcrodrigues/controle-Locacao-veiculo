using ControleLocacao.Domain.Entities;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Infra.Data.Extensions;

namespace ControleLocacao.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria, Tables.Categoria>, ICategoriaRepository
    {

        private readonly DbLocacao _dbLocacao;

        public CategoriaRepository(DbLocacao dbLocacao) : base(dbLocacao)
        {
            _dbLocacao = dbLocacao;
        }

        protected override Categoria Map(Tables.Categoria tabela)
            => tabela.Map();


        protected override Tables.Categoria Map(Categoria entidade)
            => entidade.Map();

        protected override Tables.Categoria Map(Categoria entidade, Tables.Categoria tabela)
            => tabela.Map(entidade);
    }
}
