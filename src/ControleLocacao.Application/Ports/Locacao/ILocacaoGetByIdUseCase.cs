using ControleLocacao.Application.Dto;

namespace ControleLocacao.Application.Ports.Locacaos
{
    public interface ILocacaoGetByIdUseCase
    {
        LocacaoDto? Execute(int id);
    }
}