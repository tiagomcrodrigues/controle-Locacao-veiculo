using ControleLocacao.Api.Models.Requests;
using ControleLocacao.Api.Models.Responses;
using ControleLocacao.Application.Dto;

namespace ControleLocacao.Api.Extensions

{
    public static class VeiculoExtension
    {
        public static VeiculoDto Map(this VeiculoRequest request, int? id = null)
        => new()
        {
            Id = id,
            Categotia = new() {Id = request.CategotiaId},
            Marca = request.Marca,
            Modelo = request.Modelo,
            Versao = request.Versao,
            AnoModelo = request.AnoModelo,
            AnoFabricacao = request.AnoFabricacao,
            Placa = request.Placa

        };

        public static VeiculoResponse Map(this VeiculoDto dto)
        {
            return new()
            {
                Id = dto.Id.Value,
                Categotia = dto.Categotia,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Versao = dto.Versao,
                AnoModelo = dto.AnoModelo,
                AnoFabricacao = dto.AnoFabricacao,
                Placa = dto.Placa,
                Inativo = dto.Inativo
            };

        }

    }

}
