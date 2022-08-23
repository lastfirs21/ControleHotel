using AutoMapper;
using ControleHotel.Data;
using ControleHotel.Data.Dtos.Hospedagem;
using ControleHotel.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Services
{
    public class HospedagemService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private ValidadorReserva _validadorReserva;

        public HospedagemService(AppDbContext context, IMapper mapper, ValidadorReserva validadorReserva)
        {
            _validadorReserva = validadorReserva;
            _context = context;
            _mapper = mapper;
        }
        public Result AdicionaHospedagem(CreateHospedagemDto hospedagemDto)
        {
            Hospedagem hospedagem = _mapper.Map<Hospedagem>(hospedagemDto);

            Result resultValidaHospedagem = _validadorReserva.ValidarReserva(hospedagem.QuartoId, hospedagem.DataCheckIn, hospedagem.DataCheckOut, "Hospedagem");
            if (resultValidaHospedagem.IsSuccess)
            {
                hospedagem.StatusHospedagem = StatusHospedagem.CheckedIn;
                _context.Hospedagems.Add(hospedagem);
                _context.SaveChanges();
                return resultValidaHospedagem;
            }
            return resultValidaHospedagem;
        }

        internal Result AdicionaHospedagemPorReserva(int reservaId)
        {
            Reserva reserva = _context.Reservas.First(r => r.Id == reservaId);
            if (reserva != null)
            {
                AdicionaHospedagem(_mapper.Map<CreateHospedagemDto>(reserva));
                _context.Reservas.Find(reserva).StatusReserva = StatusReserva.Confirmada;
                return Result.Ok();
            }
            else
            {
                return Result.Fail("Esta Reserva Não Existe ! ");
            }
        }

        public List<ReadHospedagemDto> RecuperaHospedagens()
        {
            List<Hospedagem> hospedagems = _context.Hospedagems.ToList();

            if (hospedagems != null)
            {
                List<ReadHospedagemDto> readDto = _mapper.Map<List<ReadHospedagemDto>>(hospedagems);
                return readDto;
            }
            return null;
        }

        public ReadHospedagemDto RecuperaHospedagensPorId(int id)
        {
            Hospedagem hospedagem = _context.Hospedagems.FirstOrDefault(hospedagem => hospedagem.Id == id);
            if (hospedagem != null)
            {
                ReadHospedagemDto hospedagemDto = _mapper.Map<ReadHospedagemDto>(hospedagem);

                return hospedagemDto;
            }
            return null;
        }

        public Result AtualizaHospedagem(int id, UpdateHospedagemDto hospedagemDto)
        {
            Hospedagem hospedagem = _context.Hospedagems.FirstOrDefault(hospedagem => hospedagem.Id == id);
            _context.Hospedagems.Remove(hospedagem);
            if (hospedagem == null)
            {
                return Result.Fail("Hospedagem não encontrada");
            }

            _context.Hospedagems.Remove(hospedagem);
            _context.SaveChanges();

            Result resultValidaHospedagem = _validadorReserva
                .ValidarReserva(hospedagemDto.QuartoId, hospedagemDto.DataCheckIn, hospedagemDto.DataCheckOut, "Hospedagem");

            if (resultValidaHospedagem.IsSuccess)
            {
                _mapper.Map(hospedagemDto, hospedagem);
                _context.Hospedagems.Add(hospedagem);
                _context.SaveChanges();
                return resultValidaHospedagem;
            }
            _context.Hospedagems.Add(hospedagem);
            _context.SaveChanges();
            return resultValidaHospedagem;
        }


        public Result DeletaHospedagem(int id)
        {
            Hospedagem hospedagem = _context.Hospedagems.FirstOrDefault(hospedagem => hospedagem.Id == id);
            if (hospedagem == null)
            {
                return Result.Fail("Hospedagem não encontrada");
            }
            _context.Hospedagems.Remove(hospedagem);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
