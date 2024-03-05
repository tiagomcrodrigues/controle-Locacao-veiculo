using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Domain.Ports
{
    public interface ICategoriaService
    {
        IResult<int> Add(Categoria categoria);
        void Delete(int id);
        IEnumerable<Categoria> GetAll();
        Categoria? GetById(int id);
        IResult<bool> Update(Categoria categoria);
    }
}