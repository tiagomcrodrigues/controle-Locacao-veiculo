using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Domain.Ports
{
    public interface ILocacaoService
    {
        IResult<int> Add(Locacao locacao);
        void Delete(int id);
        IEnumerable<Locacao> GetAll();
        Locacao? GetById(int id);
        IResult<bool> Update(Locacao locacao);
    }
}