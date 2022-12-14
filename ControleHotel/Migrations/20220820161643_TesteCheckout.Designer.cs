// <auto-generated />
using System;
using ControleHotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleHotel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220820161643_TesteCheckout")]
    partial class TesteCheckout
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ControleHotel.Models.Hospedagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCheckIn")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCheckOut")
                        .HasColumnType("datetime");

                    b.Property<int>("HospedeId")
                        .HasColumnType("int");

                    b.Property<int>("QuartoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusHospedagem")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospedeId");

                    b.HasIndex("QuartoId");

                    b.ToTable("Hospedagems");
                });

            modelBuilder.Entity("ControleHotel.Models.Hospede", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hospedes");
                });

            modelBuilder.Entity("ControleHotel.Models.Quarto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Quartos");
                });

            modelBuilder.Entity("ControleHotel.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCheckIn")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCheckOut")
                        .HasColumnType("datetime");

                    b.Property<int>("HospedeId")
                        .HasColumnType("int");

                    b.Property<int>("QuartoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusReserva")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospedeId");

                    b.HasIndex("QuartoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ControleHotel.Models.Hospedagem", b =>
                {
                    b.HasOne("ControleHotel.Models.Hospede", "Hospede")
                        .WithMany("Hospedagems")
                        .HasForeignKey("HospedeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleHotel.Models.Quarto", "Quarto")
                        .WithMany("Hospedagems")
                        .HasForeignKey("QuartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospede");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("ControleHotel.Models.Reserva", b =>
                {
                    b.HasOne("ControleHotel.Models.Hospede", "Hospede")
                        .WithMany("Reservas")
                        .HasForeignKey("HospedeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleHotel.Models.Quarto", "Quarto")
                        .WithMany("Reservas")
                        .HasForeignKey("QuartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospede");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("ControleHotel.Models.Hospede", b =>
                {
                    b.Navigation("Hospedagems");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ControleHotel.Models.Quarto", b =>
                {
                    b.Navigation("Hospedagems");

                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
