using ControleLocacao.Domain.Entities;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Infra.Data.Extensions;

namespace ControleLocacao.Infra.Data.Repositories
{
    public class VeiculoRepository : RepositoryBase<Veiculo, Tables.Veiculo>, IVeiculoRepository
    {

        private readonly DbLocacao _dbLocacao;

        public VeiculoRepository(DbLocacao dbLocacao) : base(dbLocacao)
        {
            _dbLocacao = dbLocacao;
        }

        protected override Veiculo Map(Tables.Veiculo tabela)
            => tabela.Map();


        protected override Tables.Veiculo Map(Veiculo entidade)
            => entidade.Map();

        protected override Tables.Veiculo Map(Veiculo entidade, Tables.Veiculo tabela)
            => tabela.Map(entidade);
    }
}
