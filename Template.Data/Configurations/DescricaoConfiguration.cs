using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Data.Entitys;

namespace Template.Data.Configurations
{
    public class DescricaoConfiguration : IEntityTypeConfiguration<Descricao>
    {
        public void Configure(EntityTypeBuilder<Descricao> builder)
        {
            builder
                .ToTable("Descricao");

            builder
                .HasKey(f => f.Id)
                .HasName("pk_id_descricao");

            builder
                .Property(f => f.Texto)
                .HasColumnName("texto")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
