﻿using ControleLocacao.Application.Dto;
using ControleLocacao.Domain.Entities;

namespace ControleLocacao.Application.Extensions
{
    public static class CategoriaExtension
    {
        public static Categoria Map(this CategoriaDto dto)
        {
            Categoria entidade = 
                dto.Id.HasValue 
                ? new Categoria(dto.Id.Value) 
                : new Categoria() ;
            entidade.Nome = dto.Nome;
            entidade.valorSeguro = dto.valorSeguro;
            entidade.valorDiaria = dto.valorDiaria;
            return entidade;
        }

        public static CategoriaDto? Map(this Categoria? entidade)
        {
            if (entidade == null)
                return null;
            return new(entidade.Id)
            {
                Nome = entidade.Nome,
                valorSeguro = entidade.valorSeguro,
                valorDiaria = entidade.valorDiaria
            };
        }



    }
}
