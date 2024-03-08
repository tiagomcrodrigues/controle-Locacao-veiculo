using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Ports.Locacaos
{
    public interface ILocacaoAddUseCase
    {
        IResult<int> Execute(LocacaoDto dto);
    }
}
