using ControleLocacao.Api.Models.Requests;
using FluentValidation;

namespace ControleLocacao.Api.Validators
{
    public class LocacaoValidator : AbstractValidator<LocacaoRequest>
    {
        public LocacaoValidator()
        {
            RuleFor(c => c.VeiculoId)
                    .NotEmpty().WithMessage("Campo Veiculo Id é obrigatório")
                    .GreaterThan(0).WithMessage("O Veiculo Id deve ser valido");

            RuleFor(c => c.ClienteId)
                    .NotEmpty().WithMessage("Campo Cliente Id é obrigatório")
                    .GreaterThan(0).WithMessage("O Cliente Id deve ser valido");
            RuleFor(c => c.DataRetirada)
                  .NotEmpty().WithMessage("Campo Data Retirada é obrigatório");

            RuleFor(c => c.DiariasPrevistas)
                  .NotEmpty().WithMessage("Campo Diarias Previstas é obrigatório")
                  .GreaterThan(0).WithMessage("O Diarias Previstas deve ser valido");

        }
    }
}
