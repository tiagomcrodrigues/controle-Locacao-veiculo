using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Application.Dto
{
    public class ClienteDto
    {
        public ClienteDto() { }

        public ClienteDto(int? id)
        {
            Id = id;
        }

        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? TipoPessoa { get; set; }
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

    }
}
