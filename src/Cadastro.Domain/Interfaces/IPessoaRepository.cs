using Cadastro.Domain.Models;
using System.Linq.Expressions;

namespace Cadastro.Domain.Interfaces
{
    public interface IPessoaRepository : IDisposable
    {
        Task Adicionar(Pessoa pessoa);
        Task<IEnumerable<Pessoa>> ObterTodos();
        Task<Pessoa> ObterPorId(int id);
        Task<Pessoa> BuscarPessoa(Expression<Func<Pessoa, bool>> predicate);
        Task<Cidade> BuscarCidade(Expression<Func<Cidade, bool>> predicate);
        Task Atualizar(Pessoa pessoa);
        Task Remover(Pessoa pessoa);
    }
}
