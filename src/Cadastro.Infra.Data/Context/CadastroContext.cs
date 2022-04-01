using Cadastro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Infra.Data.Context
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
