namespace Cadastro.Domain.Models
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int Idade { get; private set; }
        public int CidadeId { get; private set; }

        public Cidade Cidade { get; private set; }

        public Pessoa(string nome, string cpf, int idade)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
        }

        protected Pessoa()
        {
        }

        public void AtribuirCidade(int id)
        {
            CidadeId = id;
        }

        public void AdicionarCidade(Cidade cidade)
        {
            Cidade = cidade;
        }

        public void AtualizarDados(Pessoa pessoa)
        {
            if (pessoa.CidadeId != 0 && pessoa.CidadeId != CidadeId)
                TrocarCidade();

            Nome = pessoa.Nome;
            Cpf = pessoa.Cpf;
            Idade = pessoa.Idade;
            CidadeId = pessoa.CidadeId;
        }

        private void TrocarCidade()
        {
            Cidade = null;
        }
    }
}
