using ControleLocacao.Api.Models.Requests;
using FluentValidation;

namespace ControleLocacao.Api.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteRequest>
    {
        public ClienteValidator() 
        {

            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("Campo Nome é obrigatório")
               .Length(2, 100).WithMessage("O campo nome deve conter entre 2 e 100 caracteres");

            RuleFor(c => c.TipoPessoa)
                .NotEmpty().WithMessage("O campo tipo Prssoa e obrigatorio")
                .Length(1).WithMessage("O Tipo De Pessoa deve conter a letra  ( J ) para Juridica ou ( F ) fisica ");
                //.Must(v => "FJ".Contains(v.ToUpper())).WithMessage("O campo valor Diaria deve ser maior que 0");

            RuleFor(c => c.Documento)
                 .NotEmpty().WithMessage("Campo Documento é obrigatório")
               .Length(11, 14).WithMessage("O campo Documento deve conter entre 11 e 14 caracteres");


            RuleFor(c => c.Telefone)
               .Length(1, 15).WithMessage("O campo Telefone deve conter entre 1 e 15 caracteres");

            RuleFor(c => c.Email)
               .Length(6, 254).WithMessage("O campo Email deve conter entre 6 e 254 caracteres");

        }
    }
}
