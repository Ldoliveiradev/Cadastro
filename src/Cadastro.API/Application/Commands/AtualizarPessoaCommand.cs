using Cadastro.API.Application.Validations;
using FluentValidation.Results;
using MediatR;

namespace Cadastro.API.Application.Commands
{
    public class AtualizarPessoaCommand : IRequest<ValidationResult>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string NomeCidade { get; set; }
        public string Uf { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public AtualizarPessoaCommand(int id, string nome, string cpf, int idade, string nomeCidade, string uf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            NomeCidade = nomeCidade;
            Uf = uf;

            ValidationResult = new ValidationResult();
        }

        public bool Validar()
        {
            ValidationResult = new AtualizarPessoaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
