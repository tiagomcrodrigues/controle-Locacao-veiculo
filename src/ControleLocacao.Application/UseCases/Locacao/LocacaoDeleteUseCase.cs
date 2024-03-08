using ControleLocacao.Application.Ports.Locacaos;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Locacaos
{
    public class LocacaoDeleteUseCase : UseCaseBase<ILocacaoService>, ILocacaoDeleteUseCase
    {

        public LocacaoDeleteUseCase(ILocacaoService LocacaoService) : base(LocacaoService) { }


        public void Execute(int id)
            => _service.Delete(id);

    }
}
