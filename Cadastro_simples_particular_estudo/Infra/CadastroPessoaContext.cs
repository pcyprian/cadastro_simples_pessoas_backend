using Cadastro_simples_particular_estudo.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_simples_particular_estudo.Infra
{
    public class CadastroPessoaContext : DbContext
    {
        public CadastroPessoaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PessoaDto> Pessoas { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaDto>(_ =>
            {
                _.ToTable("pessoas");
                _.HasKey(x => x.Id);
                _.Property(x => x.Id).ValueGeneratedOnAdd();

            });
            
        }
    }
}

