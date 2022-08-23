using AutoMapper;
using ControleHotel.Data;
using ControleHotel.Data.Dtos.Quarto;
using FluentResults;
using ControleHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Services
{
    public class QuartoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public QuartoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadQuartoDto AdicionaQuarto(CreateQuartoDto QuartoDto)
        {
            Quarto Quarto = _mapper.Map<Quarto>(QuartoDto);
            _context.Quartos.Add(Quarto);
            _context.SaveChanges();
            return _mapper.Map<ReadQuartoDto>(Quarto);
        }

        public List<ReadQuartoDto> RecuperaQuartos()
        {
            List<Quarto> Quartos;

            Quartos = _context.Quartos.ToList();

            if (Quartos != null)
            {
                List<ReadQuartoDto> readDto = _mapper.Map<List<ReadQuartoDto>>(Quartos);
                return readDto;
            }
            return null;
        }

        public ReadQuartoDto RecuperaQuartosPorId(int id)
        {
            Quarto Quarto = _context.Quartos.FirstOrDefault(Quarto => Quarto.Id == id);
            if (Quarto != null)
            {
                ReadQuartoDto QuartoDto = _mapper.Map<ReadQuartoDto>(Quarto);

                return QuartoDto;
            }
            return null;
        }

        public Result AtualizaQuarto(int id, UpdateQuartoDto QuartoDto)
        {
            Quarto Quarto = _context.Quartos.FirstOrDefault(Quarto => Quarto.Id == id);
            if (Quarto == null)
            {
                return Result.Fail("Quarto não encontrado");
            }
            _mapper.Map(QuartoDto, Quarto);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaQuarto(int id)
        {
            Quarto Quarto = _context.Quartos.FirstOrDefault(Quarto => Quarto.Id == id);
            if (Quarto == null)
            {
                return Result.Fail("Quarto não encontrado");
            }
            _context.Quartos.Remove(Quarto);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
