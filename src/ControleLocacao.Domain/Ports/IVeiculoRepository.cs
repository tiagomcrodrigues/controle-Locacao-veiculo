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
        int Add(Veiculo cliente);
        void Delete(int id);
        IEnumerable<Veiculo> GetAll();
        Veiculo? GetById(int id);
        void Update(Veiculo cliente);
    }
}
