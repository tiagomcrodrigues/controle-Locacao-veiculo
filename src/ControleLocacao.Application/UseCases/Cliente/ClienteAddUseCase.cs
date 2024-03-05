using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Clientes;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Clientes
{
    public class ClienteAddUseCase  : UseCaseBase<IClienteService>, IClienteAddUseCase
    {

        public ClienteAddUseCase(IClienteService ClienteService) : base(ClienteService) { }
        
        public IResult<int> Execute(ClienteDto dto)
            => _service.Add(dto.Map());

    }
}
