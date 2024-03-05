using ControleLocacao.Application.Dto;

namespace ControleLocacao.Application.Ports.Clientes
{
    public interface IClienteGetAllUseCase
    {
        IEnumerable<ClienteDto?> Execute();
    }
}