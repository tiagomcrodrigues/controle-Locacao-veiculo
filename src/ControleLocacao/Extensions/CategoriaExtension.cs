using ControleLocacao.Api.Models.Requests;
using ControleLocacao.Api.Models.Responses;
using ControleLocacao.Application.Dto;


namespace ControleLocacao.Api.Extensions
{
    public static class CategoriaExtension
    {
        public static CategoriaDto Map(this CategoriaRequest request,int? id=null)
            => new()
            {
                Id = id,
                Nome = request.Nome,
                valorDiaria = request.ValorDiaria,
                valorSeguro = request.ValorSeguro
            };

        public static CategoriaResponse Map(this CategoriaDto dto)
        {
            return new()
            {
                Id = dto.Id.Value,
                Nome = dto.Nome,
                valorDiaria = dto.valorDiaria,
                valorSeguro = dto.valorSeguro
            };
        }



    }
}

