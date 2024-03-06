using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Ports.Veiculos
{
    public interface IVeiculoAddUseCase
    {
        IResult<int> Execute(VeiculoDto dto);
    }
}
