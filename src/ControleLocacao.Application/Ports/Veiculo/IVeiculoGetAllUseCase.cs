using ControleLocacao.Application.Dto;

namespace ControleLocacao.Application.Ports.Veiculos
{
    public interface IVeiculoGetAllUseCase
    {
        IEnumerable<VeiculoDto?> Execute();
    }
}