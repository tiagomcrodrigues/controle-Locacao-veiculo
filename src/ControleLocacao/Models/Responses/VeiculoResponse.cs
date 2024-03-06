using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Api.Models.Responses
{
    public class VeiculoResponse
    {
        public int? Id { get;  set; }
        public SimpleIdNameModel Categotia { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Versao { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string? Placa { get; set; }
        public bool Inativo { get; set; } 
    }
}
