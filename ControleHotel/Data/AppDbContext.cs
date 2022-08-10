using ControleHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<Reserva>()
               .HasOne(reserva => reserva.Quarto)
               .WithMany(quarto => quarto.Reservas)
               .HasForeignKey(reserva => reserva.QuartoId);


            builder.Entity<Reserva>()
               .HasOne(reserva => reserva.Hospede)
               .WithMany(hospede => hospede.Reservas)
               .HasForeignKey(reserva => reserva.HospedeId);
        }
        public DbSet<Hospede> Hospedes { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        //  public DbSet<Filme> Filmes { get; set; } (padrao para adicionar um dbset)
    }
}
