using AutoMapper;
using ControleHotel.Data;
using ControleHotel.Data.Dtos.Hospede;
using System;
using ControleHotel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using ControleHotel.Data.Dtos.Reserva;

namespace ControleHotel.Services
{
    public class ReservaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ReservaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Result AdicionaReserva(CreateReservaDto ReservaDto)
        {
            Reserva reserva = _mapper.Map<Reserva>(ReservaDto);

            if (ValidaReserva(reserva))
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail($"Já Existe Reserva Neste Quarto Para o Dia " + reserva.DataCheckIn.Date.ToShortDateString() + "!");
        }



        public bool ValidaReserva(Reserva reserva)
        {
            List<Reserva> reservasQuarto = _context.Reservas.Where(r => r.QuartoId == reserva.QuartoId) // verifica reservas nos quartos
                .Where(r=> r.DataCheckIn.DayOfYear + r.DiasReserva - reserva.DataCheckIn.DayOfYear >0) // verifica reservas no periodo
                .ToList();
            // TODO:  Terminar de fazer verificação da data, colocar verificação de tempo de reserva efetuado
            if (reservasQuarto.Count() > 0 )
            {
                return false;

            }
            else
            {
                return true;
            }



        }


        public List<ReadReservaDto> RecuperaReservas()
        {
            List<Reserva> Reservas;

            Reservas = _context.Reservas.ToList();

            if (Reservas != null)
            {
                List<ReadReservaDto> readDto = _mapper.Map<List<ReadReservaDto>>(Reservas);
                return readDto;
            }
            return null;
        }

        public ReadReservaDto RecuperaReservasPorId(int id)
        {
            Reserva Reserva = _context.Reservas.FirstOrDefault(Reserva => Reserva.Id == id);
            if (Reserva != null)
            {
                ReadReservaDto ReservaDto = _mapper.Map<ReadReservaDto>(Reserva);

                return ReservaDto;
            }
            return null;
        }

        public Result AtualizaReserva(int id, UpdateReservaDto ReservaDto)
        {
            Reserva Reserva = _context.Reservas.FirstOrDefault(Reserva => Reserva.Id == id);
            if (Reserva == null)
            {
                return Result.Fail("Reserva não encontrado");
            }
            _mapper.Map(ReservaDto, Reserva);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaReserva(int id)
        {
            Reserva Reserva = _context.Reservas.FirstOrDefault(Reserva => Reserva.Id == id);
            if (Reserva == null)
            {
                return Result.Fail("Reserva não encontrado");
            }
            _context.Remove(Reserva);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
