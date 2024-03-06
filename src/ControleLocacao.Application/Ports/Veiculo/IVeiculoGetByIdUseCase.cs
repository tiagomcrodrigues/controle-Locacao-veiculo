using ControleLocacao.Application.Dto;

namespace ControleLocacao.Application.Ports.Veiculos
{
    public interface IVeiculoGetByIdUseCase
    {
        VeiculoDto? Execute(int id);
    }
}