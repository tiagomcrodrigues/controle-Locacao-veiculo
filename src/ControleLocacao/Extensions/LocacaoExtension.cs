using ControleLocacao.Api.Models.Requests;
using ControleLocacao.Api.Models.Responses;
using ControleLocacao.Application.Dto;

namespace ControleLocacao.Api.Extensions

{
    public static class LocacaoExtension
    {
        public static LocacaoDto Map(this LocacaoRequest reques, int? id = null)
        => new()
        {
            Id = id,
            Veiculo = new() { Id = reques.VeiculoId },
            Cliente = new() { Id = reques.ClienteId },
            DataRetirada = reques.DataRetirada.ToLocalTime(),
            DiariasPrevistas = reques.DiariasPrevistas

        };

        public static LocacaoResponse Map(this LocacaoDto dto)
            => new()
            {
                Id = dto.Id.Value,
                Veiculo = new() { Id = dto.Veiculo.Id.Value, Nome = dto.Veiculo.Modelo },
                Cliente = dto.Cliente,
                DataRetirada = dto.DataRetirada.Value,
                DataLimite = dto.DataLimite.Value,
                DataEntrega = dto.DataEntrega,
                ValorDiaria = dto.ValorDiaria.Value,
                ValorSeguro = dto.ValorSeguro.Value,
                DiariasPrevistas = dto.DiariasPrevistas.Value,
                DiariasRealizada = dto.DiariasRealizada,
                TotalPrevisto = dto.TotalPrevisto.Value,
                TotalPago = dto.TotalPago
            };

        public static DevolucaDto Map(this LocacaoDevolucao devoluca,int id)
        => new()
        {
            Id = id,
            DiariasRealizada = devoluca.DiariasRealizada.Value

        };

    }

}
