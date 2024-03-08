using ControleLocacao.Api.Models.Requests;
using FluentValidation;

namespace ControleLocacao.Api.Validators
{
    public class LocacaoDevolucaoValidator : AbstractValidator<LocacaoDevolucao>
    {
        public LocacaoDevolucaoValidator()
        {
            RuleFor(c => c.DiariasRealizada)
                    .NotEmpty().WithMessage("Campo Diarias Realizada é obrigatório")
            .GreaterThan(0).WithMessage("O Diarias Realizada deve ser valido");
        }
    }
}
