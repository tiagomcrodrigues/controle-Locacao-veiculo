using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Locacaos;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Locacaos
{
    public class LocacaoGetAllUseCase : UseCaseBase<ILocacaoService>, ILocacaoGetAllUseCase
    {
        public LocacaoGetAllUseCase(ILocacaoService service) : base(service) { }

        public IEnumerable<LocacaoDto?> Execute()
            => _service.GetAll().Select(s => s.Map());


    }
}
