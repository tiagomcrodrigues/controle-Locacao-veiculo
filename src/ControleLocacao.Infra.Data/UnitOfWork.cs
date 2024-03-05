using ControleLocacao.CrossCutting.Common.Abstractions;

namespace ControleLocacao.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbLocacao _dbLocacao;

        public UnitOfWork(DbLocacao dbLocacao)
        {
            _dbLocacao = dbLocacao;
        }

        public void BeginTransaction()
            => _dbLocacao.Database.BeginTransaction();

        public void Commit()
            => _dbLocacao.Database.CommitTransaction();

        public void RollBack()
            => _dbLocacao.Database.RollbackTransaction();
    }
}
