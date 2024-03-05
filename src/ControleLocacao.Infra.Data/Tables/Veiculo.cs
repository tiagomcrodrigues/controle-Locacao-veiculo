using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Infra.Data.Tables
{
    public class Veiculo : IKeyIdentitication
    {
        public int Id { get; private set; }
        public int CategotiaId { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Documento { get; set; }
        public string? Versao { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string? Placa { get; set; }
        public bool Inativo { get; set; } 
    }
}
