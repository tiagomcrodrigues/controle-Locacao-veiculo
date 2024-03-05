using ControleLocacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleLocacao.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity,TTable>
        where TEntity : class, IKeyIdentitication
        where TTable : class, IKeyIdentitication
    {

        private readonly DbLocacao _dbLocacao;
        private readonly DbSet<TTable> _dbSet;

        protected abstract TEntity Map(TTable tabela);

        protected abstract TTable Map(TEntity entidade);

        protected abstract TTable Map(TEntity entidade, TTable tabela);

        protected virtual TTable? Find(int id)
            => _dbSet.Find(id);

        protected virtual IQueryable<TTable> GetRows()
            => _dbSet;

        public RepositoryBase(DbLocacao dbLocacao)
        {
            _dbLocacao = dbLocacao;
            _dbSet = _dbLocacao.Set<TTable>();
        }

        public virtual int Add(TEntity entidade)
        {
            TTable tabela = Map(entidade);
            _dbSet.Add(tabela);
            _dbLocacao.SaveChanges();
            return tabela.Id;
        }

        public virtual void Delete(int id)
        {
            TTable? tabela = Find(id);
            if (tabela != null)
            {
                _dbSet.Remove(tabela);
                _dbLocacao.SaveChanges(true);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
            => GetRows()
            .ToList()
            .Select(c => Map(c));


        public virtual TEntity? GetById(int id)
        {
            TTable? tabela = Find(id);
            if (tabela == null)
                return null;
            return Map(tabela);
        }

        public virtual void Update(TEntity entidade)
        {
            TTable? tabela = Find(entidade.Id);
            if (tabela != null)
            {
                Map(entidade, tabela);
                _dbLocacao.SaveChanges();
            }
        }

    }
}
