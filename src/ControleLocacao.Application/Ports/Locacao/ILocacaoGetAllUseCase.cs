using ControleLocacao.Application.Dto;

namespace ControleLocacao.Application.Ports.Locacaos
{
    public interface ILocacaoGetAllUseCase
    {
        IEnumerable<LocacaoDto?> Execute();
    }
}