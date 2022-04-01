namespace Cadastro.API.Models.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public int CidadeId { get; set; }
        public string NomeCidade { get; set; }
        public string Uf { get; set; }
    }
}
