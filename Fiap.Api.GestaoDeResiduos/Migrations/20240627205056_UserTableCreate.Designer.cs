﻿// <auto-generated />
using Fiap.Api.GestaoDeResiduos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Api.GestaoDeResiduos.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240627205056_UserTableCreate")]
    partial class UserTableCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.AterroModel", b =>
                {
                    b.Property<int>("ID_ATERRO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_ATERRO"));

                    b.Property<string>("NM_LOCALIZACAO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("QTD_ATERRO")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("QTD_ATUAL")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("ST_CAPACIDADE")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("ID_ATERRO");

                    b.ToTable("T_ATERRO", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.CaminhaoModel", b =>
                {
                    b.Property<int>("ID_CAMINHAO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_CAMINHAO"));

                    b.Property<string>("NM_LOCALIZACAO")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("QTD_ATUAL")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("VL_CAPACIDADE")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID_CAMINHAO");

                    b.ToTable("T_CAMINHAO", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.ColetaModel", b =>
                {
                    b.Property<int>("ID_COLETA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_COLETA"));

                    b.Property<string>("NM_LOCALIZACAO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("ST_COLETA")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("T_CAMINHAO_ID_CAMINHAO")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID_COLETA");

                    b.HasIndex("T_CAMINHAO_ID_CAMINHAO");

                    b.ToTable("T_COLETA", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.FuncionarioModel", b =>
                {
                    b.Property<int>("ID_FUNCIONARIO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_FUNCIONARIO"));

                    b.Property<string>("NM_DEPT")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NM_FUNCAO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NM_FUNCIONARIO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("T_CAMINHAO_ID_CAMINHAO")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID_FUNCIONARIO");

                    b.HasIndex("T_CAMINHAO_ID_CAMINHAO");

                    b.ToTable("T_FUNCIONARIO", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.RotaModel", b =>
                {
                    b.Property<int>("ID_ROTA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_ROTA"));

                    b.Property<int>("T_ATERRO_ID_ATERRO")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("T_CAMINHAO_ID_CAMINHAO")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID_ROTA");

                    b.HasIndex("T_ATERRO_ID_ATERRO");

                    b.HasIndex("T_CAMINHAO_ID_CAMINHAO");

                    b.ToTable("T_ROTA", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_USER");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasDefaultValue("operador")
                        .HasColumnName("ROLE");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("USERNAME");

                    b.HasKey("UserId");

                    b.ToTable("T_USER", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.ColetaModel", b =>
                {
                    b.HasOne("Fiap.Api.GestaoDeResiduos.Model.CaminhaoModel", "Caminhao")
                        .WithMany("Coletas")
                        .HasForeignKey("T_CAMINHAO_ID_CAMINHAO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caminhao");
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.FuncionarioModel", b =>
                {
                    b.HasOne("Fiap.Api.GestaoDeResiduos.Model.CaminhaoModel", "Caminhao")
                        .WithMany("Funcionarios")
                        .HasForeignKey("T_CAMINHAO_ID_CAMINHAO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caminhao");
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.RotaModel", b =>
                {
                    b.HasOne("Fiap.Api.GestaoDeResiduos.Model.AterroModel", "Aterro")
                        .WithMany("Rota")
                        .HasForeignKey("T_ATERRO_ID_ATERRO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Api.GestaoDeResiduos.Model.CaminhaoModel", "Caminhao")
                        .WithMany("Rota")
                        .HasForeignKey("T_CAMINHAO_ID_CAMINHAO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aterro");

                    b.Navigation("Caminhao");
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.AterroModel", b =>
                {
                    b.Navigation("Rota");
                });

            modelBuilder.Entity("Fiap.Api.GestaoDeResiduos.Model.CaminhaoModel", b =>
                {
                    b.Navigation("Coletas");

                    b.Navigation("Funcionarios");

                    b.Navigation("Rota");
                });
#pragma warning restore 612, 618
        }
    }
}
