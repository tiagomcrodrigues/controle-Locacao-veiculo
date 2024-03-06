using System.ComponentModel.DataAnnotations;

namespace ControleLocacao.Api.Models.Requests
{
    public class CategoriaRequest
    {
        public string Nome { get; set; }
        public double ValorDiaria { get; set; }
        public double ValorSeguro { get; set; }

    }
}
