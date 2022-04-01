using Cadastro.API.Application.Commands;
using FluentValidation;

namespace Cadastro.API.Application.Validations
{
    public class RemoverPessoaValidation : AbstractValidator<RemoverPessoaCommand>
    {
        public RemoverPessoaValidation()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0).WithMessage("O campo {PropertyName} está vazio");
        }        
    }
}
