using ControleLocacao.Application.Dto;

namespace ControleLocacao.Application.Ports.Clientes
{
    public interface IClienteGetByIdUseCase
    {
        ClienteDto? Execute(int id);
    }
}