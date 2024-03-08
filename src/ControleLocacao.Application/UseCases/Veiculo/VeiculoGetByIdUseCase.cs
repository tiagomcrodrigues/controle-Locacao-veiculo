using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Veiculos;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Veiculos
{
    public class VeiculoGetByIdUseCase : UseCaseBase<IVeiculoService>, IVeiculoGetByIdUseCase
    {
        public VeiculoGetByIdUseCase(IVeiculoService service) : base(service)
        {
        }

        public VeiculoDto? Execute(int id)
            => _service.GetById(id).Map();


    }
}
