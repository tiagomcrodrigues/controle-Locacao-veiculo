using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Domain.Ports
{
    public interface IVeiculoService
    {
        IResult<int> Add(Veiculo veiculo);
        void Delete(int id);
        IEnumerable<Veiculo> GetAll();
        Veiculo? GetById(int id);
        IResult<bool> Update(Veiculo veiculo);
    }
}
