using Cadastro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infra.Data.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Uf)
                .HasMaxLength(2)
                .IsRequired();

            builder.HasMany(c => c.Pessoas)
                .WithOne(p => p.Cidade)
                .HasForeignKey(p => p.CidadeId);
        }
    }
}
