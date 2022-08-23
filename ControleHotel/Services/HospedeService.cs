using AutoMapper;
using ControleHotel.Data;
using ControleHotel.Models;
using ControleHotel.Data.Dtos.Hospede;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace ControleHotel.Services
{
    public class HospedeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public HospedeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadHospedeDto AdicionaHospede(CreateHospedeDto HospedeDto)
        {
            Hospede Hospede = _mapper.Map<Hospede>(HospedeDto);
            _context.Hospedes.Add(Hospede);
            _context.SaveChanges();
            return _mapper.Map<ReadHospedeDto>(Hospede);
        }

        public List<ReadHospedeDto> RecuperaHospedes()
        {
            List<Hospede> Hospedes;
     
                Hospedes = _context.Hospedes.ToList();

            if (Hospedes != null)
            {
                List<ReadHospedeDto> readDto = _mapper.Map<List<ReadHospedeDto>>(Hospedes);
                return readDto;
            }
            return null;
        }

        public ReadHospedeDto RecuperaHospedesPorId(int id)
        {
            Hospede Hospede = _context.Hospedes.FirstOrDefault(Hospede => Hospede.Id == id);
            if (Hospede != null)
            {
                ReadHospedeDto HospedeDto = _mapper.Map<ReadHospedeDto>(Hospede);

                return HospedeDto;
            }
            return null;
        }

        public Result AtualizaHospede(int id, UpdateHospedeDto HospedeDto)
        {
            Hospede Hospede = _context.Hospedes.FirstOrDefault(Hospede => Hospede.Id == id);
            if (Hospede == null)
            {
                return Result.Fail("Hospede não encontrado");
            }
            _mapper.Map(HospedeDto, Hospede);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaHospede(int id)
        {
            Hospede Hospede = _context.Hospedes.FirstOrDefault(Hospede => Hospede.Id == id);
            if (Hospede == null)
            {
                return Result.Fail("Hospede não encontrado");
            }
            _context.Hospedes.Remove(Hospede);
            _context.SaveChanges();
            return Result.Ok();
        }



    }
}
