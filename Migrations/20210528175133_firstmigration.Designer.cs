﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetoPainel.Models.Data;

namespace ProjetoPainel.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210528175133_firstmigration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_carteirapessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int?>("BPId")
                        .HasColumnType("integer");

                    b.Property<int>("Cod_carteira")
                        .HasColumnType("integer");

                    b.Property<int?>("CoordenadorId")
                        .HasColumnType("integer");

                    b.Property<int?>("ExecutivoId")
                        .HasColumnType("integer");

                    b.Property<int>("Id_executivo")
                        .HasColumnType("integer");

                    b.Property<int?>("LiderTecnicoId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProgramadorId")
                        .HasColumnType("integer");

                    b.Property<int?>("SuperId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BPId");

                    b.HasIndex("CoordenadorId");

                    b.HasIndex("ExecutivoId");

                    b.HasIndex("LiderTecnicoId");

                    b.HasIndex("ProgramadorId");

                    b.HasIndex("SuperId");

                    b.ToTable("rpa_carteirapessoa");
                });

            modelBuilder.Entity("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("Cargo")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("rpa_pessoa");
                });

            modelBuilder.Entity("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_carteirapessoa", b =>
                {
                    b.HasOne("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_pessoa", "BP")
                        .WithMany()
                        .HasForeignKey("BPId");

                    b.HasOne("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_pessoa", "Coordenador")
                        .WithMany()
                        .HasForeignKey("CoordenadorId");

                    b.HasOne("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_pessoa", "Executivo")
                        .WithMany()
                        .HasForeignKey("ExecutivoId");

                    b.HasOne("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_pessoa", "LiderTecnico")
                        .WithMany()
                        .HasForeignKey("LiderTecnicoId");

                    b.HasOne("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_pessoa", "Programador")
                        .WithMany()
                        .HasForeignKey("ProgramadorId");

                    b.HasOne("RPA._000.RetornaCarteirasAPI.Models.Entities.Rpa_pessoa", "Super")
                        .WithMany()
                        .HasForeignKey("SuperId");

                    b.Navigation("BP");

                    b.Navigation("Coordenador");

                    b.Navigation("Executivo");

                    b.Navigation("LiderTecnico");

                    b.Navigation("Programador");

                    b.Navigation("Super");
                });
#pragma warning restore 612, 618
        }
    }
}
