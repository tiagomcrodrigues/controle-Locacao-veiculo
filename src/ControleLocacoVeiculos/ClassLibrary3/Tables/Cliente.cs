using ControleLocacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Infra.Data.Tables
{
    public class Cliente : IKeyIdentitication
    {
        public int Id { get; private set; }
        public string? Nome { get; set; }
        public string? TipoPessoa { get; set; }
        public string? Documento { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        
    }
}
