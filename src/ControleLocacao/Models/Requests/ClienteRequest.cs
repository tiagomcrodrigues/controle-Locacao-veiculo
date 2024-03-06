using System.ComponentModel.DataAnnotations;

namespace ControleLocacao.Api.Models.Requests
{
    public class ClienteRequest
    {
       
        public string? Nome { get; set; }
        public string? TipoPessoa { get; set; }
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

    }
}
