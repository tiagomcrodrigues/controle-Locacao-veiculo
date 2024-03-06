using ControleLocacao.Api.Models.Requests;
using FluentValidation;

namespace ControleLocacao.Api.Validators
{
    public class CategoriaValidator : AbstractValidator<CategoriaRequest>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Campo Nome é obrigatório")
                .Length(2, 100).WithMessage("O campo nome deve conter entre 2 e 100 caracteres");

            RuleFor(c => c.ValorDiaria)
                .GreaterThan(0).WithMessage("O campo valor Diaria deve ser maior que 0");

            RuleFor(c => c.ValorSeguro)
                .GreaterThan(0).WithMessage("O campo valor seguro deve ser maior que 0");
        }

    }
}
