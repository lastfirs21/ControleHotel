using ControleHotel.Data;
using ControleHotel.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Services
{
    public class ValidadorReserva
    {

        private AppDbContext _context;
        public ValidadorReserva(AppDbContext context)
        {
            _context = context;
        }


        public Result ValidarReserva(int quartoId, DateTime checkIn, DateTime checkOut, string tipo)
        {


            if (checkIn > checkOut)
            {
                return Result.Fail("A Data de CheckIn Deve ser Menor que a de CheckOut");
            }
            if (checkIn == checkOut)
            {
                return Result.Fail("As " + tipo + "s devem ser de pelo menos 1 Dia!");
            }

            List<Hospedagem> hospedagems = _context.Hospedagems
                .Where(q => q.QuartoId == quartoId)
                .Where(
                h => (h.DataCheckIn <= checkIn && h.DataCheckOut >= checkIn) ||
                   (checkOut >= h.DataCheckIn && checkOut <= h.DataCheckOut))
                .ToList();

            List<Reserva> reservas = _context.Reservas
           .Where(q => q.QuartoId == quartoId)
           .Where(
           h => (h.DataCheckIn <= checkIn && h.DataCheckOut >= checkIn) ||
              (checkOut >= h.DataCheckIn && checkOut <= h.DataCheckOut))
           .ToList();

            if (reservas.Count > 0 || hospedagems.Count > 0)
            {
                return Result.Fail("Já Existem " + tipo + "s No Período do Dia " +
                    checkIn.ToShortDateString() + " ao Dia " + checkOut.ToShortDateString() + " no Quarto "+ quartoId + "!");
            }

            return Result.Ok();
        }
    }
}
