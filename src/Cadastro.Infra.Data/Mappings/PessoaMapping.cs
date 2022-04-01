using Cadastro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infra.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.Idade)
                .IsRequired();

            builder.HasOne(p => p.Cidade)
                .WithMany(c => c.Pessoas);
        }
    }
}
