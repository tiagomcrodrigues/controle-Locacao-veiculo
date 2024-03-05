namespace ControleLocacao.Api.Models.Responses
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double valorDiaria { get; set; }
        public double valorSeguro { get; set; }
    }
}
