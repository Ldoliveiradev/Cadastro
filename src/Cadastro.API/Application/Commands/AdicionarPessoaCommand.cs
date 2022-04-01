using Cadastro.API.Application.Validations;
using FluentValidation.Results;
using MediatR;

namespace Cadastro.API.Application.Commands
{
    public class AdicionarPessoaCommand : IRequest<ValidationResult>
    {        
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string NomeCidade { get; set; }
        public string Uf { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public AdicionarPessoaCommand(string nome, string cpf, int idade, string nomeCidade, string uf)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            NomeCidade = nomeCidade;
            Uf = uf;

            ValidationResult = new ValidationResult();
        }

        public bool Validar()
        {
            ValidationResult = new AdicionarPessoaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
