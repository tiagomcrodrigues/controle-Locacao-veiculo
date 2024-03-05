using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Ports.Clientes
{
    public interface IClienteUpdateUseCase
    {
        IResult<bool> Execute(ClienteDto dto);
    }
}