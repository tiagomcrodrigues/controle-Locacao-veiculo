using ControleLocacao.Api.Extensions;
using ControleLocacao.Api.Models.Requests;
using ControleLocacao.Api.Models.Responses;
using ControleLocacao.Application.Ports.Veiculos;
using ControleLocacao.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleLocacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoAddUseCase _veiculoAddUseCase;
        private readonly IVeiculoGetAllUseCase _veiculoGetAllUseCase;
        private readonly IVeiculoGetByIdUseCase _veiculoGetByIdUseCase;
        private readonly IVeiculoUpdateUseCase _veiculoUpdateUseCase;
        private readonly IVeiculoDeleteUseCase _veiculoDeleteUseCase;

        public VeiculoController
        (
            IVeiculoAddUseCase veiculoAddUseCase,
            IVeiculoGetAllUseCase veiculoGetAllUseCase,
            IVeiculoGetByIdUseCase veiculoGetByIdUseCase,
            IVeiculoUpdateUseCase veiculoUpdateUseCase,
            IVeiculoDeleteUseCase veiculoDeleteUseCase
        )
        {
            _veiculoAddUseCase = veiculoAddUseCase;
            _veiculoGetAllUseCase = veiculoGetAllUseCase;
            _veiculoGetByIdUseCase = veiculoGetByIdUseCase;
            _veiculoUpdateUseCase = veiculoUpdateUseCase;
            _veiculoDeleteUseCase = veiculoDeleteUseCase;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] VeiculoRequest request)
        {
            var result = _veiculoAddUseCase.Execute(request.Map());
            if (result.Success)
                return Created(uri: string.Empty, new { id = result.Data.ToString() });

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_veiculoGetAllUseCase.Execute().Select(s => s.Map()));


        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _veiculoGetByIdUseCase.Execute(id);
            if (result == null)
                return NotFound(new NotificacaoModel(nameof(Veiculo), "Registro não encontrado"));
            return Ok(result.Map());
        }

        [HttpPut("{id:int}")]
        public IActionResult Editar([FromRoute] int id, [FromBody] VeiculoRequest request)
        {
            if (_veiculoGetByIdUseCase.Execute(id) == null)
                return NotFound(new NotificacaoModel(nameof(Veiculo), "Registro não encontrado"));

            var result = _veiculoUpdateUseCase.Execute(request.Map(id));
            if (result.Success)
                return NoContent();

            return UnprocessableEntity(result.Errors.CapturaCriticas());

        }

        [HttpDelete("{id:int}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            _veiculoDeleteUseCase.Execute(id);
            return NoContent();
        }


    }
}
