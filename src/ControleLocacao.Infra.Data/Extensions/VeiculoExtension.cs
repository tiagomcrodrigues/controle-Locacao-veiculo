using tb = ControleLocacao.Infra.Data.Tables;
using dm = ControleLocacao.Domain.Entities;
using System.Numerics;
using System.Text.RegularExpressions;
using System;

namespace ControleLocacao.Infra.Data.Extensions
{
    public static class VeiculoExtension
    {
        public static tb.Veiculo Map(this dm.Veiculo entidade)
        {
            return new tb.Veiculo()
            {
                CategotiaId = entidade.CategotiaId,
                Marca = entidade.Marca,
                Modelo = entidade.Modelo,
                Versao = entidade.Versao,
                AnoModelo = entidade.AnoModelo,
                AnoFabricacao = entidade.AnoFabricacao,
                Placa = entidade.Placa,
                Inativo = entidade.Inativo
                
            };
        }

        public static dm.Veiculo Map(this tb.Veiculo tabela)
             => new(tabela.Id)
             {
                 CategotiaId = tabela.CategotiaId,
                 Marca = tabela.Marca,
                 Modelo = tabela.Modelo,
                 Versao = tabela.Versao,
                 AnoModelo = tabela.AnoModelo,
                 AnoFabricacao = tabela.AnoFabricacao,
                 Placa = tabela.Placa,
                 Inativo = tabela.Inativo
             };

        public static tb.Veiculo Map(this tb.Veiculo tabela, dm.Veiculo entidade)
        {
            tabela.CategotiaId = entidade.CategotiaId;
            tabela.Marca = entidade.Marca;
            tabela.Modelo = entidade.Modelo;
            tabela.Versao = entidade.Versao;
            tabela.AnoModelo = entidade.AnoModelo;
            tabela.AnoFabricacao = entidade.AnoFabricacao;
            tabela.Placa = entidade.Placa;
            tabela.Inativo = entidade.Inativo;
            return tabela;
        }

    }

}
