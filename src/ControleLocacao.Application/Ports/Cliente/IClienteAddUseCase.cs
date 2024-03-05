using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Ports.Clientes
{
    public interface IClienteAddUseCase
    {
        IResult<int> Execute(ClienteDto dto);
    }
}
