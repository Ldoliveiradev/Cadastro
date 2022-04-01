using AutoMapper;
using Cadastro.API.Application.Commands;
using Cadastro.API.Models.Dtos;
using Cadastro.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cadastro.API.Controllers
{
    [Route("api/[controller]")]
    public class PessoasController : MainController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PessoasController(IPessoaRepository pessoaRepository, IMapper mapper, IMediator mediator)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PessoaDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterTodos()
        {
            return CustomResponse(_mapper.Map<IEnumerable<PessoaDto>>(await _pessoaRepository.ObterTodos()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PessoaDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterPessoaPorId(int id)
        {
            var pessoaDto = await ObterPessoa(id);

            if (pessoaDto == null) return NotFound();

            return CustomResponse(pessoaDto);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Adicionar(PessoaDto pessoaDto)
        {
            return CustomResponse(await _mediator.Send(new AdicionarPessoaCommand(pessoaDto.Nome, pessoaDto.Cpf, pessoaDto.Idade,
                pessoaDto.NomeCidade, pessoaDto.Uf)));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Atualizar(int id, PessoaDto pessoaDto)
        {
            if (id != pessoaDto.Id)
            {
                return NotFound();
            }

            return CustomResponse(await _mediator.Send(new AtualizarPessoaCommand(pessoaDto.Id, pessoaDto.Nome, pessoaDto.Cpf,
                pessoaDto.Idade, pessoaDto.NomeCidade, pessoaDto.Uf)));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Excluir(int id)
        {
            var pessoaDto = await ObterPessoa(id);

            if (pessoaDto == null) return NotFound();

            return CustomResponse(await _mediator.Send(new RemoverPessoaCommand(id)));
        }

        private async Task<PessoaDto> ObterPessoa(int id)
        {
            return _mapper.Map<PessoaDto>(await _pessoaRepository.ObterPorId(id));
        }
    }
}
