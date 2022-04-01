namespace Cadastro.Domain.Models
{
    public class Cidade
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Uf { get; private set; }

        private readonly List<Pessoa> _pessoas;
        public IReadOnlyCollection<Pessoa> Pessoas => _pessoas;

        public Cidade(string nome, string uf)
        {
            Nome = nome;
            Uf = uf;

            _pessoas = new List<Pessoa>();
        }

        protected Cidade()
        {
        }
    }
}
