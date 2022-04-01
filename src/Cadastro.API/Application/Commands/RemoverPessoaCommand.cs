using Cadastro.API.Application.Validations;
using FluentValidation.Results;
using MediatR;

namespace Cadastro.API.Application.Commands
{
    public class RemoverPessoaCommand : IRequest<ValidationResult>
    {
        public int Id { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public RemoverPessoaCommand(int id)
        {
            Id = id;

            ValidationResult = new ValidationResult();
        }

        public bool Validar()
        {
            ValidationResult = new RemoverPessoaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
