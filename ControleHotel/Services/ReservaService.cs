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
        public ReadReservaDto AdicionaReserva(CreateReservaDto ReservaDto)
        {
            Reserva Reserva = _mapper.Map<Reserva>(ReservaDto);
            _context.Reservas.Add(Reserva);
            _context.SaveChanges();
            return _mapper.Map<ReadReservaDto>(Reserva);
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
