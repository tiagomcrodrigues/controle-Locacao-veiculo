using System.ComponentModel.DataAnnotations;

namespace ControleLocacao.Api.Models.Requests
{
    public class CategoriaRequest
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 100 caracteres")]
        public string Nome { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "O campo valor Diaria deve conter entre 1 e 9.999.999.999.999.999,99")]
        public double valorDiaria { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "O campo valor seguro deve conter entre 1 e 9.999.999.999.999.999,99")]
        public double valorSeguro { get; set; }

    }
}
