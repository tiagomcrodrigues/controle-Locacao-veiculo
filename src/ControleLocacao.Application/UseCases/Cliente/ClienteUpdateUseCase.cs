using ControleLocacao.Application.Dto;
using ControleLocacao.Application.Extensions;
using ControleLocacao.Application.Ports.Clientes;
using ControleLocacao.CrossCutting.Common.Models;
using ControleLocacao.Domain.Ports;

namespace ControleLocacao.Application.UseCases.Clientes
{
    public class ClienteUpdateUseCase : UseCaseBase<IClienteService>, IClienteUpdateUseCase
    {
        public ClienteUpdateUseCase(IClienteService service) : base(service)
        {
        }

        public IResult<bool> Execute(ClienteDto dto)
            =>_service.Update(dto.Map());



    }
}
