using ControleLocacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Domain.Ports
{
    public interface IVeiculoRepository
    {
        int Add(Veiculo veiculo);
        void Delete(int id);
        IEnumerable<Veiculo> GetAll();
        Veiculo? GetById(int id);
        void Update(Veiculo vaiculo);
    }
}
