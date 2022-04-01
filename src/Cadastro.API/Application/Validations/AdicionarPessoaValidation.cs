using Cadastro.API.Application.Commands;
using FluentValidation;

namespace Cadastro.API.Application.Validations
{
    public class AdicionarPessoaValidation : AbstractValidator<AdicionarPessoaCommand>
    {
        public AdicionarPessoaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(3, 300)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(11)
                .WithMessage("O campo {PropertyName} precisa ter 11 caracteres");

            RuleFor(c => c.Idade)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser preenchido");

            RuleFor(c => c.NomeCidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(3, 300)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Uf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2)
                .WithMessage("O campo {PropertyName} precisa ter 2 caracteres");
        }
    }
}
