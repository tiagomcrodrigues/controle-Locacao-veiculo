using System.ComponentModel.DataAnnotations;

namespace ControleLocacao.Api.Models.Requests
{
    public class ClienteRequest
    {
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 50 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Tipo Pessoa é obrigatório")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "O campo Tipo Pessoa deve (F) para pessoa fisica ou (J) para judridica")]
        public string? TipoPessoa { get; set; }

        [Required(ErrorMessage = "Campo documento é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo documento deve conter entre 11 e 14 caracteres")]
        public string? Documento { get; set; }

        [StringLength(15, MinimumLength = 2, ErrorMessage = "O campo telefone deve conter 15 caracteres")]
        public string? Telefone { get; set; }

        [StringLength(254, MinimumLength = 2, ErrorMessage = "O campo Email deve conter entre 2 e 254 caracteres")]
        public string? Email { get; set; }

    }
}
