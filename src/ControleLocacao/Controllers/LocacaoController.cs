using ControleLocacao.Api.Extensions;
using ControleLocacao.Api.Models.Requests;
using ControleLocacao.Api.Models.Responses;
using ControleLocacao.Application.Ports.Locacaos;
using ControleLocacao.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoAddUseCase _locacaoAddUseCase;
        private readonly ILocacaoGetAllUseCase _locacaoGetAllUseCase;
        private readonly ILocacaoGetByIdUseCase _locacaoGetByIdUseCase;
        private readonly ILocacaoUpdateUseCase _locacaoUpdateUseCase;
        private readonly ILocacaoDeleteUseCase _locacaoDeleteUseCase;

        public LocacaoController
        (
            ILocacaoAddUseCase locacaoAddUseCase,
            ILocacaoGetAllUseCase locacaoGetAllUseCase,
            ILocacaoGetByIdUseCase locacaoGetByIdUseCase,
            ILocacaoUpdateUseCase locacaoUpdateUseCase,
            ILocacaoDeleteUseCase locacaoDeleteUseCase
        )
        {
            _locacaoAddUseCase = locacaoAddUseCase;
            _locacaoGetAllUseCase = locacaoGetAllUseCase;
            _locacaoGetByIdUseCase = locacaoGetByIdUseCase;
            _locacaoUpdateUseCase = locacaoUpdateUseCase;
            _locacaoDeleteUseCase = locacaoDeleteUseCase;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] LocacaoRequest request)
        {
            var result = _locacaoAddUseCase.Execute(request.Map());
            if (result.Success)
                return Created(uri: string.Empty, new { id = result.Data.ToString() });

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_locacaoGetAllUseCase.Execute().Select(s => s.Map()));



        [HttpPatch("{id:int}")]
        public IActionResult Devolucao([FromRoute]int id , [FromBody] LocacaoDevolucao request)
        {
            if (_locacaoGetByIdUseCase.Execute(id) == null)
                return NotFound(new NotificacaoModel(nameof(Locacao), "Registro não encontrado"));

            var result = _locacaoUpdateUseCase.Execute(request.Map(id));
            if (result.Success)
                return NoContent();

            return UnprocessableEntity(result.Errors.CapturaCriticas());

        }

    }

}
