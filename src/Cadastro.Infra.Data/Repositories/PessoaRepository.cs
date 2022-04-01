using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cadastro.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly CadastroContext _context;

        public PessoaRepository(CadastroContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pessoa>> ObterTodos()
        {
            return await _context.Pessoas.Include(c => c.Cidade).ToListAsync();
        }

        public async Task<Pessoa> ObterPorId(int id)
        {
            return await _context.Pessoas.Include(c => c.Cidade).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Pessoa> BuscarPessoa(Expression<Func<Pessoa, bool>> predicate)
        {
            return await _context.Pessoas.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<Cidade> BuscarCidade(Expression<Func<Cidade, bool>> predicate)
        {
            return await _context.Cidades.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task Atualizar(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
