using ControleLocacao.Application.Ports.Clientes;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Clientes
{
    public class ClienteDeleteUseCase : UseCaseBase<IClienteService>, IClienteDeleteUseCase
    {

        public ClienteDeleteUseCase(IClienteService ClienteService) : base(ClienteService) { }


        public void Execute(int id)
            => _service.Delete(id);

    }
}
