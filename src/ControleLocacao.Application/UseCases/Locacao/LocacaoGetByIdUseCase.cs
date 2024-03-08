using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Locacaos;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Locacaos
{
    public class LocacaoGetByIdUseCase : UseCaseBase<ILocacaoService>, ILocacaoGetByIdUseCase
    {
        public LocacaoGetByIdUseCase(ILocacaoService service) : base(service)
        {
        }

        public LocacaoDto? Execute(int id)
            => _service.GetById(id).Map();


    }
}
