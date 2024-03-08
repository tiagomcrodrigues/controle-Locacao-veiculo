using ControleLocacao.Domain.Entities;
using ControleLocacao.Domain.Ports;
using ControleLocacao.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ControleLocacao.Infra.Data.Repositories
{
    public class LocacaoRepository : RepositoryBase<Locacao, Tables.Locacao>, ILocacaoRepository
    {

        private readonly DbLocacao _dbLocacao;

        public LocacaoRepository(DbLocacao dbLocacao) : base(dbLocacao)
        {
            _dbLocacao = dbLocacao;
        }




        protected override Locacao Map(Tables.Locacao tabela)
            => tabela.Map();


        protected override Tables.Locacao Map(Locacao entidade)
            => entidade.Map();

        protected override Tables.Locacao Map(Locacao entidade, Tables.Locacao tabela)
            => tabela.Map(entidade);

        Locacao? ILocacaoRepository.GetAlugago(int id)
        {
            var result = GetRows()
            .Where(a => a.Veiculo.Id == id && a.DiariasRealizada == null)
            .FirstOrDefault();

            if (result == null)
                return null;

            return result.Map();
        }

    }
}
