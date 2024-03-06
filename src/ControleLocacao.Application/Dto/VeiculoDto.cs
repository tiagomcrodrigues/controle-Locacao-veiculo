using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Application.Dto
{
    public class VeiculoDto 
    {

        public VeiculoDto() { }

        public VeiculoDto(int id)
        {
            Id = id;
        }

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
