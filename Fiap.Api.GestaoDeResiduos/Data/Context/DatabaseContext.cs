using Fiap.Api.GestaoDeResiduos.Model;
using Fiap.Api.GestaoDeResiduos.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Api.GestaoDeResiduos.Data.Context
{
	public class DatabaseContext : DbContext
	{
		public virtual DbSet<FuncionarioModel> Funcionarios { get; set; }
		public virtual DbSet<AterroModel> Aterros { get; set; }
		public virtual DbSet<RotaModel> Rotas { get; set; }
		public virtual DbSet<CaminhaoModel> Caminhoes { get; set; }
		public virtual DbSet<ColetaModel> Coletas { get; set; }
		public virtual DbSet<UserModel> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Aterro model
			modelBuilder.Entity<AterroModel>(entity =>
			{
				entity.ToTable("T_ATERRO");
				entity.HasKey(e => e.ID_ATERRO);
                entity.Property(e => e.QTD_ATUAL).IsRequired();
				entity.Property(e => e.QTD_ATERRO).IsRequired();
				entity.Property(e => e.NM_LOCALIZACAO).IsRequired();
				entity.Property(e => e.ST_CAPACIDADE).HasColumnType("NUMBER(1)").IsRequired();
			});

			// Caminhao model
			modelBuilder.Entity<CaminhaoModel>(entity =>
			{
				entity.ToTable("T_CAMINHAO");
				entity.HasKey(e => e.ID_CAMINHAO);
				entity.Property(e => e.QTD_ATUAL).IsRequired();
				entity.Property(e => e.VL_CAPACIDADE).IsRequired();
				entity.Property(e => e.NM_LOCALIZACAO);
			});

			// Coleta Model
			modelBuilder.Entity<ColetaModel>(entity =>
			{
				entity.ToTable("T_COLETA");
				entity.HasKey(e => e.ID_COLETA);
				entity.Property(e => e.NM_LOCALIZACAO).IsRequired();
				entity.Property(e => e.ST_COLETA).HasColumnType("NUMBER(1)").IsRequired();

				// Relacionamento com Caminhao
				entity.HasOne(e => e.Caminhao).WithMany(p => p.Coletas).HasForeignKey(e => e.T_CAMINHAO_ID_CAMINHAO);
			});

			// Funcionario Model
			modelBuilder.Entity<FuncionarioModel>(entity =>
			{
				entity.ToTable("T_FUNCIONARIO");
				entity.HasKey(e => e.ID_FUNCIONARIO);
				entity.Property(e => e.NM_FUNCIONARIO).IsRequired();
				entity.Property(e => e.NM_FUNCAO).IsRequired();
				entity.Property(e => e.NM_DEPT).IsRequired();

				// Relacionamento com Caminhao
				entity.HasOne(e => e.Caminhao).WithMany(p => p.Funcionarios).HasForeignKey(e => e.T_CAMINHAO_ID_CAMINHAO);
			});

			// Rota Model
			modelBuilder.Entity<RotaModel>(entity =>
			{
				entity.ToTable("T_ROTA");
				entity.HasKey(e => e.ID_ROTA);

				// Relacionamento com Caminhao
				entity.HasOne(e => e.Caminhao).WithMany(e => e.Rota).HasForeignKey(e => e.T_CAMINHAO_ID_CAMINHAO);

				// Relacionamento com Aterro
				entity.HasOne(e => e.Aterro).WithMany(e => e.Rota).HasForeignKey(e => e.T_ATERRO_ID_ATERRO);

			});

			// User model
			modelBuilder.Entity<UserModel>(entity =>
			{
				entity.ToTable("T_USER");
                entity.HasKey(e => e.UserId);
				entity.Property(e => e.UserId).HasColumnName("ID_USER");
                entity.Property(e => e.Username).HasColumnName("USERNAME").IsRequired();
                entity.Property(e => e.Password).HasColumnName("PASSWORD").IsRequired();
                entity.Property(e => e.Role).HasColumnName("ROLE").HasDefaultValue("operador");
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
