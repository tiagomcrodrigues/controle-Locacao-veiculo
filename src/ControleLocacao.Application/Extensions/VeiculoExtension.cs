using ControleLocacao.Application.Dto;
using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Application.Extensions
{
    public static class VeiculoExtension
    {
        public static Veiculo Map(this VeiculoDto dto)
        {
            Veiculo entidade =
                dto.Id.HasValue
                ? new Veiculo(dto.Id.Value)
                : new Veiculo();
            entidade.Categotia = dto.Categotia;
            entidade.Marca = dto.Marca;
            entidade.Modelo = dto.Modelo;
            entidade.Versao = dto.Versao;
            entidade.AnoModelo = dto.AnoModelo;
            entidade.AnoFabricacao = dto.AnoFabricacao;
            entidade.Placa = dto.Placa;
            entidade.Inativo = dto.Inativo;
            return entidade;

        }

        public static VeiculoDto Map(this Veiculo entidade)
        {
            if (entidade == null)
                return null;
            return new(entidade.Id)
            {
                Categotia = entidade.Categotia,
                Marca = entidade.Marca,
                Modelo = entidade.Modelo,
                Versao = entidade.Versao,
                AnoModelo = entidade.AnoModelo,
                AnoFabricacao = entidade.AnoFabricacao,
                Placa = entidade.Placa,
                Inativo = entidade.Inativo
            };

        }

    }

}
