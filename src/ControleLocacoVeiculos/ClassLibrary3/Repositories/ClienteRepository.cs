using ControleLocacao.Domain.Entities;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Infra.Data.Extensions;

namespace ControleLocacao.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente, Tables.Cliente>, IClienteRepository
    {

        private readonly DbLocacao _dbLocacao;

        public ClienteRepository(DbLocacao dbLocacao) : base(dbLocacao)
        {
            _dbLocacao = dbLocacao;
        }


        protected override Cliente Map(Tables.Cliente tabela)
            => tabela.Map();

        protected override Tables.Cliente Map(Cliente entidade)
            => entidade.Map();

        protected override Tables.Cliente Map(Cliente entidade, Tables.Cliente tabela)
            => tabela.Map(entidade);
    }
}
