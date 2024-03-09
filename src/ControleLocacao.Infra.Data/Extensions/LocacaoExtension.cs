using tb = ControleLocacao.Infra.Data.Tables;
using dm = ControleLocacao.Domain.Entities;
using System.Numerics;
using System.Text.RegularExpressions;
using System;

namespace ControleLocacao.Infra.Data.Extensions
{
    public static class LocacaoExtension
    {
        public static tb.Locacao Map(this dm.Locacao entidade)
        {
            return new tb.Locacao()
            {
                ClienteId = entidade.Cliente.Id,
                VeiculoId = entidade.Veiculo.Id,
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

        public static dm.Locacao Map(this tb.Locacao tabela)
             => new(tabela.Id)
             {
                 Veiculo = new()
                 {
                     Id = tabela.VeiculoId,
                     Modelo = ($"{tabela.Veiculo.Modelo} {tabela.Veiculo.Versao}" )
                 },

                 Cliente = new()
                 {
                     Id = tabela.ClienteId,
                     Nome = tabela.Cliente.Nome
                 },
                 DataRetirada = tabela.DataRetirada,
                 DataLimite = tabela.DataLimite,
                 DataEntrega = tabela.DataEntrega,
                 ValorDiaria = tabela.ValorDiaria,
                 ValorSeguro = tabela.ValorSeguro,
                 DiariasPrevistas = tabela.DiariasPrevistas,
                 DiariasRealizada = tabela.DiariasRealizada,
                 TotalPrevisto = tabela.TotalPrevisto,
                 TotalPago = tabela.TotalPago
             };

        public static tb.Locacao Map(this tb.Locacao tabela, dm.Locacao entidade)
        {
            tabela.VeiculoId = entidade.Veiculo.Id;
            tabela.ClienteId = entidade.Cliente.Id;
            tabela.DataRetirada = entidade.DataRetirada;
            tabela.DataLimite = entidade.DataLimite;
            tabela.DataEntrega = entidade.DataEntrega;
            tabela.ValorDiaria = entidade.ValorDiaria;
            tabela.ValorSeguro = entidade.ValorSeguro;
            tabela.DiariasPrevistas = entidade.DiariasPrevistas;
            tabela.DiariasRealizada = entidade.DiariasRealizada;
            tabela.TotalPrevisto = entidade.TotalPrevisto;
            tabela.TotalPago = entidade.TotalPago;

            return tabela;
        }

    }

}
