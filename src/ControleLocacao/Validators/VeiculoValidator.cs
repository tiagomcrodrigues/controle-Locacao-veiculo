using ControleLocacao.Api.Models.Requests;
using FluentValidation;

namespace ControleLocacao.Api.Validators
{
    public class VeiculoValidator : AbstractValidator<VeiculoRequest>
    {

        public VeiculoValidator()
        {
            RuleFor(c => c.CategoriaId)
                .NotEmpty().WithMessage("Campo Categoria Id é obrigatório");

            RuleFor(c => c.Marca)
                .NotEmpty().WithMessage("Campo Marca é obrigatório")
                .Length(2, 80).WithMessage("O campo Marca deve conter entre 2 e 80 caracteres");

            RuleFor(c => c.Modelo)
                .NotEmpty().WithMessage("Campo Modelo é obrigatório")
                .Length(2, 50).WithMessage("O campo Modelo deve conter entre 2 e 50 caracteres");

            RuleFor(c => c.Versao)
                .NotEmpty().WithMessage("Campo Versao é obrigatório")
                .Length(2, 150).WithMessage("O campo Versao deve conter entre 2 e 150 caracteres");


            RuleFor(c => c.AnoModelo)
                .GreaterThan(0).WithMessage("O campo Ano Modelo deve ser maior que 0");

            RuleFor(c => c.AnoFabricacao)
                .GreaterThan(0).WithMessage("O campo Ano Fabricacao deve ser maior que 0");

            RuleFor(c => c.Placa)
              .NotEmpty().WithMessage("Campo Placa e obrigatorio")
              .Length(7).WithMessage("O Placa deve conter 7 caracteres ");

        }

    }
}
