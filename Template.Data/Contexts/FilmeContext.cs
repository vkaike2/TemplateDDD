using Microsoft.EntityFrameworkCore;
using Template.Data.Configuration;
using Template.Data.Models;

namespace Template.Data.Context
{
    public class FilmeContext : DbContext
    {
        public DbSet<Filme> Filme { get; set; }
        public FilmeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());
        }
    }
}
