using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Application.Extensions
{
    public static class LocacaoExtension
    {
        public static Locacao Map(this LocacaoDto dto)
        {
            Locacao entidade =
               dto.Id.HasValue
               ? new Locacao(dto.Id.Value)
               : new Locacao();
            entidade.Cliente = new() { Id = dto.Cliente.Id };
            entidade.Veiculo = new Veiculo() { Id = dto.Veiculo.Id.Value };
            entidade.DataRetirada = dto.DataRetirada.Value;
            entidade.DiariasPrevistas = dto.DiariasPrevistas.Value;
            return entidade;
        }


        public static Devolucao Map(this DevolucaDto dto)
        {
            Devolucao entidade =
               dto.Id.HasValue
               ? new Devolucao(dto.Id.Value)
               : new Devolucao();
            entidade.DiariasRealizada = dto.DiariasRealizada;
            return entidade;
        }

        public static LocacaoDto Map(this Locacao entidade)
        {
            if (entidade == null)
                return null;
            return new(entidade.Id)
            {
                Veiculo = entidade.Veiculo.Map(),
                Cliente = entidade.Cliente,
                DataRetirada = entidade.DataRetirada,
                DataLimite = entidade.DataLimite,
                DataEntrega = entidade.DataEntrega,
                ValorDiaria = entidade.ValorDiaria,
                ValorSeguro = entidade.ValorSeguro,
                DiariasPrevistas = entidade.DiariasPrevistas,
                DiariasRealizada = entidade.DiariasRealizada,
                TotalPrevisto = entidade.TotalPrevisto,
                TotalPago = entidade.TotalPago
            };

        }

    }

}
