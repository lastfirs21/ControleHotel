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
        private ValidadorReserva _validadorReserva;

        public ReservaService(AppDbContext context, IMapper mapper, ValidadorReserva validadorReserva)
        {
            _validadorReserva = validadorReserva;
            _context = context;
            _mapper = mapper;
        }
        public Result AdicionaReserva(CreateReservaDto ReservaDto)
        {
            Reserva reserva = _mapper.Map<Reserva>(ReservaDto);

            Result validaReserva = _validadorReserva.ValidarReserva(reserva.QuartoId, reserva.DataCheckIn, reserva.DataCheckOut, "Reserva");
            if (validaReserva.IsSuccess)
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return validaReserva;
            }
            return validaReserva;
        }



        public List<ReadReservaDto> RecuperaReservas()
        {
            List<Reserva> reserva;

            reserva = _context.Reservas.ToList();

            if (reserva != null)
            {
                List<ReadReservaDto> readDto = _mapper.Map<List<ReadReservaDto>>(reserva);
                return readDto;
            }
            return null;
        }

        public ReadReservaDto RecuperaReservasPorId(int id)
        {
            Reserva reserva = _context.Reservas.FirstOrDefault(reserva => reserva.Id == id);
            if (reserva != null)
            {
                ReadReservaDto reservaDto = _mapper.Map<ReadReservaDto>(reserva);

                return reservaDto;
            }
            return null;
        }

        public Result AtualizaReserva(int id, UpdateReservaDto reservaDto)
        {
            Reserva reserva = _context.Reservas.FirstOrDefault(reserva => reserva.Id == id);
            if (reserva == null)
            {
                return Result.Fail("Reserva não encontrada");
            }
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
            Result validaReserva = _validadorReserva.ValidarReserva(reservaDto.QuartoId, reservaDto.DataCheckIn, reservaDto.DataCheckOut, "Reserva");
            if (validaReserva.IsSuccess)
            {
                _mapper.Map(reservaDto, reserva);
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return validaReserva;
            }
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
            return validaReserva;


        }

        public Result DeletaReserva(int id)
        {
            Reserva reserva = _context.Reservas.FirstOrDefault(reserva => reserva.Id == id);
            if (reserva == null)
            {
                return Result.Fail("Reserva não encontrada");
            }
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
            return Result.Ok();
        }


    }
}
