using ControleLocacao.Application.Dto;
using ControleLocacao.CrossCutting.Common.Models;

namespace ControleLocacao.Application.Ports.Locacaos
{
    public interface ILocacaoUpdateUseCase
    {
        IResult<bool> Execute(DevolucaDto dto);
    }
}