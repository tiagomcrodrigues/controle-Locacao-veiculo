using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Veiculos;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Veiculos
{
    public class VeiculoGetAllUseCase : UseCaseBase<IVeiculoService>, IVeiculoGetAllUseCase
    {
        public VeiculoGetAllUseCase(IVeiculoService service) : base(service) { }

        public IEnumerable<VeiculoDto?> Execute()
            => _service.GetAll().Select(s => s.Map());


    }
}
