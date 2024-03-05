using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Clientes;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Clientes
{
    public class ClienteGetByIdUseCase : UseCaseBase<IClienteService>, IClienteGetByIdUseCase
    {
        public ClienteGetByIdUseCase(IClienteService service) : base(service)
        {
        }

        public ClienteDto? Execute(int id)
            => _service.GetById(id).Map();


    }
}
