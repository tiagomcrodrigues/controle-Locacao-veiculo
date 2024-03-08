using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Veiculos;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Veiculos
{
    public class VeiculoUpdateUseCase : UseCaseBase<IVeiculoService>, IVeiculoUpdateUseCase
    {
        public VeiculoUpdateUseCase(IVeiculoService service) : base(service)
        {
        }

        public IResult<bool> Execute(VeiculoDto dto)
            =>_service.Update(dto.Map());



    }
}
