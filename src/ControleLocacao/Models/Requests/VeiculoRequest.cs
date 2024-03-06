namespace ControleLocacao.Api.Models.Requests
{
    public class VeiculoRequest
    {
        
        public int CategotiaId { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Versao { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }
        public string? Placa { get; set; }
    }
}
