using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Data.Models;

namespace Template.Data.Configuration
{
    class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder
                .ToTable("Filme");

            builder
                .HasKey(f => f.Id)
                .HasName("pk_id_filme");

            builder
                .Property(f => f.Nome)
                .HasColumnName("nome_filme")
                .HasColumnType("varchar (30)")
                .IsRequired();

            builder
                .Property(f => f.FaixaEtaria)
                .HasColumnName("faixaetaria")
                .HasColumnType("varchar (30)")
                .IsRequired();
        }
    }
}
