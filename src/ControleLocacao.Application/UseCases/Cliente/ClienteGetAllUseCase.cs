using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Clientes;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Clientes
{
    public class ClienteGetAllUseCase : UseCaseBase<IClienteService>, IClienteGetAllUseCase
    {
        public ClienteGetAllUseCase(IClienteService service) : base(service) { }

        public IEnumerable<ClienteDto?> Execute()
            => _service.GetAll().Select(s => s.Map());


    }
}
