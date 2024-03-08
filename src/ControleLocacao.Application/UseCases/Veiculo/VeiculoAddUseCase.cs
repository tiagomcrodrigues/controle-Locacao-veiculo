using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Veiculos;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Veiculos
{
    public class VeiculoAddUseCase  : UseCaseBase<IVeiculoService>, IVeiculoAddUseCase
    {

        public VeiculoAddUseCase(IVeiculoService VeiculoService) : base(VeiculoService) { }
        
        public IResult<int> Execute(VeiculoDto dto)
            => _service.Add(dto.Map());

    }
}
