using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Infra.Data.Tables
{
    public class Locacao : IKeyIdentitication
    {
        public int Id { get; private set; }
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorSeguro { get; set; }
        public int DiariasPrevistas { get; set; }
        public double TotalPrevisto { get; set; }
        public int? DiariasRealizada { get; set; }
        public double? TotalPago { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Veiculo Veiculo { get; set; }
    }
}
