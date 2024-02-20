﻿// <auto-generated />
using API_ASPPE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_ASPPE.Migrations
{
    [DbContext(typeof(APContext))]
    partial class APContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_ASPPE.Models.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("TorneioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TorneioId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("API_ASPPE.Models.EquipeEtapa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<int>("EtapaId")
                        .HasColumnType("int");

                    b.Property<double>("Peso")
                        .HasColumnType("double");

                    b.Property<double>("Pontuacao")
                        .HasColumnType("double");

                    b.Property<int>("QuantidadePeixe")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("EtapaId");

                    b.ToTable("EquipeEtapa");
                });

            modelBuilder.Entity("API_ASPPE.Models.Etapa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("TorneioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TorneioId");

                    b.ToTable("Etapas");
                });

            modelBuilder.Entity("API_ASPPE.Models.Torneio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DataInicio")
                        .HasColumnType("longtext");

                    b.Property<string>("Localizacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Torneios");
                });

            modelBuilder.Entity("API_ASPPE.Models.Equipe", b =>
                {
                    b.HasOne("API_ASPPE.Models.Torneio", "Torneio")
                        .WithMany("Equipes")
                        .HasForeignKey("TorneioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Torneio");
                });

            modelBuilder.Entity("API_ASPPE.Models.EquipeEtapa", b =>
                {
                    b.HasOne("API_ASPPE.Models.Equipe", "Equipe")
                        .WithMany()
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_ASPPE.Models.Etapa", "Etapa")
                        .WithMany("EquipesParticipantes")
                        .HasForeignKey("EtapaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Etapa");
                });

            modelBuilder.Entity("API_ASPPE.Models.Etapa", b =>
                {
                    b.HasOne("API_ASPPE.Models.Torneio", "Torneio")
                        .WithMany("Etapas")
                        .HasForeignKey("TorneioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Torneio");
                });

            modelBuilder.Entity("API_ASPPE.Models.Etapa", b =>
                {
                    b.Navigation("EquipesParticipantes");
                });

            modelBuilder.Entity("API_ASPPE.Models.Torneio", b =>
                {
                    b.Navigation("Equipes");

                    b.Navigation("Etapas");
                });
#pragma warning restore 612, 618
        }
    }
}
