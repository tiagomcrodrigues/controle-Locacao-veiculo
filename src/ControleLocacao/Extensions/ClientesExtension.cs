using ControleLocacao.Api.Models.Requests;
using ControleLocacao.Api.Models.Responses;
using ControleLocacao.Application.Dto;

namespace ControleLocacao.Api.Extensions
{
    public static class ClientesExtension
    {
        public static ClienteDto Map(this ClienteRequest request, int? id = null)
            => new()
            {
                Id = id,
                Nome = request.Nome,
                TipoPessoa = request.TipoPessoa,
                Documento = request.Documento,
                Telefone = request.Telefone,
                Email = request.Email
            };

        public static ClienteResponse Map(this ClienteDto dto)
        {
            return new()
            {
                Id = dto.Id.Value,
                Nome = dto.Nome,
                TipoPessoa = dto.TipoPessoa,
                Documento = dto.Documento,
                Telefone = dto.Telefone,
                Email = dto.Email
            };
        }

    }
}
