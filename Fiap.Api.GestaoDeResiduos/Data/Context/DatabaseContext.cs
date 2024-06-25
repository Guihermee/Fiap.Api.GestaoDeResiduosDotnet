using Fiap.Api.GestaoDeResiduos.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.GestaoDeResiduos.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<AterroModel> Aterros { get; set; }
        public DbSet<RotaModel> Rotas { get; set; }
        public DbSet<CaminhaoModel> Caminhoes { get; set; }
        public DbSet<ColetaModel> Coletas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aterro model
            modelBuilder.Entity<AterroModel>( entity =>
            {
                entity.ToTable("Aterro");
                entity.HasKey(e => e.IdAterro);
                entity.Property(e => e.QtdAterro).IsRequired();
                entity.Property(e => e.NmLocalizacao).IsRequired();
                entity.Property(e => e.StCapacidade).HasColumnType("NUMBER(1)").IsRequired();
            });

            // Caminhao model
            modelBuilder.Entity<CaminhaoModel>(entity =>
            {
                entity.ToTable("Caminhao");
                entity.HasKey(e => e.IdCaminhao);
                entity.Property(e => e.NmLocalizacao).IsRequired();
            });

            // Coleta Model
            modelBuilder.Entity<ColetaModel>(entity =>
            {
                entity.ToTable("Coleta");
                entity.HasKey(e => e.IdColeta);
                entity.Property(e => e.NmLocalizacao).IsRequired();
                entity.Property(e => e.StColeta).HasColumnType("NUMBER(1)").IsRequired();

                // Relacionamento com Caminhao
                entity.HasOne(e => e.Caminhao).WithMany(p => p.Coletas).HasForeignKey(e => e.IdCaminhao);
            });

            // Funcionario Model
            modelBuilder.Entity<FuncionarioModel>(entity =>
            {
                entity.ToTable("Funcionario");
                entity.HasKey(e => e.IdFuncionario);
                entity.Property(e => e.NmFuncionario).IsRequired();
                entity.Property(e => e.NmFuncao).IsRequired();
                entity.Property(e => e.NmDept).IsRequired();

                // Relacionamento com Caminhao
                entity.HasOne(e => e.Caminhao).WithMany(p => p.Funcionarios).HasForeignKey(e => e.IdCaminhao);
            });

            // Rota Model
            modelBuilder.Entity<RotaModel>(entity =>
            {
                entity.ToTable("Rota");
                entity.HasKey(e => e.IdRota);

                // Relacionamento com Caminhao
                entity.HasOne(e => e.Caminhao).WithOne(p => p.Rota).HasForeignKey<RotaModel>(e => e.IdCaminhao);

                // Relacionamento com Aterro
                entity.HasOne(e => e.Aterro).WithOne(p => p.Rota).HasForeignKey<AterroModel>(e => e.IdAterro);
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }
    }
}
