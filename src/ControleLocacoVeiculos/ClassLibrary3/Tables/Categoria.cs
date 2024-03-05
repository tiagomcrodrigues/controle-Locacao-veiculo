﻿using ControleLocacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Infra.Data.Tables
{
    public class Categoria : IKeyIdentitication
    {

        public int Id { get; set; }
        public string? Nome { get; set; }
        public double valorDiaria { get; set; }
        public double valorSeguro { get; set; }
    }
}
