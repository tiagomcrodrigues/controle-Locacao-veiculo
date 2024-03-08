using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Domain.Ports
{
    public interface ILocacaoRepository
    {
        int Add(Locacao locacao);
        void Delete(int id);
        IEnumerable<Locacao> GetAll();
        Locacao? GetAlugago(int id);
        Locacao? GetById(int id);
        void Update(Locacao locacao);
    }
}
