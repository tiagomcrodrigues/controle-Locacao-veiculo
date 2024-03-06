using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Ports.Veiculos
{
    public interface IVeiculoUpdateUseCase
    {
        IResult<bool> Execute(VeiculoDto dto);
    }
}