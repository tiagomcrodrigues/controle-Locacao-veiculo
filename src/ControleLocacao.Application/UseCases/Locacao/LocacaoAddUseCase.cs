using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Locacaos;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Locacaos
{
    public class LocacaoAddUseCase  : UseCaseBase<ILocacaoService>, ILocacaoAddUseCase
    {

        public LocacaoAddUseCase(ILocacaoService LocacaoService) : base(LocacaoService) { }
        
        public IResult<int> Execute(LocacaoDto dto)
            => _service.Add(dto.Map());

    }
}
