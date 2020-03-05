using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Data.Entitys;

namespace Template.Data.Configuration
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
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
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(f => f.DescricaoId)
                .HasColumnName("descricao_id");

            builder.HasOne(f => f.Descricao)
                .WithOne(d => d.Filme);
        }
    }
}
