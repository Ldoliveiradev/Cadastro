using AutoMapper;
using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace Cadastro.API.Application.Commands
{
    public class PessoaCommandHandler : CommandHandler,
        IRequestHandler<AdicionarPessoaCommand, ValidationResult>,
        IRequestHandler<AtualizarPessoaCommand, ValidationResult>,
        IRequestHandler<RemoverPessoaCommand, ValidationResult>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarPessoaCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validar()) return request.ValidationResult;

            if (await VerificarCpfExiste(request.Cpf))
            {
                AdicionarErro("CPF já cadastrado");
                return ValidationResult;
            }

            var pessoa = new Pessoa(request.Nome, request.Cpf, request.Idade);

            var cidadeExistente = await VerificarCidadeExistente(request.NomeCidade);

            if (cidadeExistente != null)
            {
                pessoa.AtribuirCidade(cidadeExistente.Id);
            }
            else
            {
                pessoa.AdicionarCidade(new Cidade(request.NomeCidade, request.Uf));
            }

            await _pessoaRepository.Adicionar(pessoa);

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(AtualizarPessoaCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validar()) return request.ValidationResult;

            if (await VerificarCpfExiste(request.Cpf, request.Id))
            {
                AdicionarErro("CPF já cadastrado");
                return ValidationResult;
            }

            var pessoaAtualizada = new Pessoa(request.Nome, request.Cpf, request.Idade);

            var cidadeExistente = await VerificarCidadeExistente(request.NomeCidade);

            if (cidadeExistente != null)
            {
                pessoaAtualizada.AtribuirCidade(cidadeExistente.Id);
            }
            else
            {
                pessoaAtualizada.AdicionarCidade(new Cidade(request.NomeCidade, request.Uf));
            }

            var pessoa = await ObterPessoa(request.Id);

            if (pessoa == null)
            {
                AdicionarErro("Pessoa não encontrada");
                return ValidationResult;
            }

            pessoa.AdicionarCidade(pessoaAtualizada.Cidade);
            pessoa.AtualizarDados(pessoaAtualizada);

            await _pessoaRepository.Atualizar(pessoa);

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(RemoverPessoaCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validar()) return request.ValidationResult;

            var pessoa = await ObterPessoa(request.Id);

            if (pessoa == null)
            {
                AdicionarErro("Pessoa não encontrada");
                return ValidationResult;
            }

            await _pessoaRepository.Remover(pessoa);

            return ValidationResult;
        }

        private async Task<bool> VerificarCpfExiste(string cpf, int id)
        {
            return await _pessoaRepository.BuscarPessoa(p => p.Cpf == cpf && p.Id == id) != null ? false : true;
        }

        private async Task<bool> VerificarCpfExiste(string cpf)
        {
            return await _pessoaRepository.BuscarPessoa(p => p.Cpf == cpf) == null ? false : true;
        }

        private async Task<Cidade> VerificarCidadeExistente(string nome)
        {
            return await _pessoaRepository.BuscarCidade(c => c.Nome == nome);
        }

        private async Task<Pessoa> ObterPessoa(int id)
        {
            return await _pessoaRepository.ObterPorId(id);
        }
    }
}
