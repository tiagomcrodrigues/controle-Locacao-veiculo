using ControleLocacao.Application.Ports.Veiculos;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Veiculos
{
    public class VeiculoDeleteUseCase : UseCaseBase<IVeiculoService>, IVeiculoDeleteUseCase
    {

        public VeiculoDeleteUseCase(IVeiculoService VeiculoService) : base(VeiculoService) { }


        public void Execute(int id)
            => _service.Delete(id);

    }
}
