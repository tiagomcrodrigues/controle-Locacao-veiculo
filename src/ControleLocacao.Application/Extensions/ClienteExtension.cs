using ControleLocacao.Application.Dto;
using ControleLocacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ControleLocacao.Application.Extensions
{
    public static class ClienteExtension
    {
        public static Cliente Map(this ClienteDto dto )
        {
            Cliente entidade =
                dto.Id.HasValue
                ? new Cliente(dto.Id.Value)
                : new Cliente();
            entidade.Nome = dto.Nome;
            entidade.TipoPessoa = dto.TipoPessoa.ToUpper();
            entidade.Documento = dto.Documento;
            entidade.Telefone = dto.Telefone;
            entidade.Email = dto.Email;
            return entidade;
        }


        public static ClienteDto? Map(this Cliente? entidade)
        {
            if (entidade == null)
                return null;
            return new(entidade.Id)
            {
                Nome = entidade.Nome,
                TipoPessoa = entidade.TipoPessoa.ToUpper(),
                Documento = entidade.Documento,
                Telefone = entidade.Telefone,
                Email = entidade.Email
            };


        }



    }
}
