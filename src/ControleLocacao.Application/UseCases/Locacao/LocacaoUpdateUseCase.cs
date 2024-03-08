using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Locacaos;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Locacaos
{
    public class LocacaoUpdateUseCase : UseCaseBase<ILocacaoService>, ILocacaoUpdateUseCase
    {
        public LocacaoUpdateUseCase(ILocacaoService service) : base(service)
        {
        }

        public IResult<bool> Execute(DevolucaDto dto)
            =>_service.Update(dto.Map());



    }
}
