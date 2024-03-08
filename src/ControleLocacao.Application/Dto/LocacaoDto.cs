using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Dto
{
    public class LocacaoDto
    {
        public LocacaoDto()
        {
        }

        public LocacaoDto(int id)
        {
            Id = id;
        }
        public int? Id { get;  set; }
        public SimpleIdNameModel? Cliente { get; set; }
        public VeiculoDto? Veiculo { get; set; }
        public DateTime? DataRetirada { get; set; }
        public DateTime? DataLimite { get; set; }
        public DateTime? DataEntrega { get; set; }
        public double? ValorDiaria { get; set; }
        public double? ValorSeguro { get; set; }
        public int? DiariasPrevistas { get; set; }
        public double? TotalPrevisto { get; set; }
        public int? DiariasRealizada { get; set; }
        public double? TotalPago { get; set; }

    }
}
