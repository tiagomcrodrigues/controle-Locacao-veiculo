using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Api.Models.Responses
{
    public class LocacaoResponse
    {
        public int Id { get;  set; }
        public SimpleIdNameModel Cliente { get; set; }
        public SimpleIdNameModel Veiculo { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorSeguro { get; set; }
        public int DiariasPrevistas { get; set; }
        public double TotalPrevisto { get; set; }
        public int? DiariasRealizada { get; set; }
        public double? TotalPago { get; set; }
    }
}
