using AutoMapper;
using ControleHotel.Data.Dtos.Reserva;
using ControleHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Profiles
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<CreateReservaDto, Reserva>();
            CreateMap<Reserva, ReadReservaDto>();
            CreateMap<UpdateReservaDto, Hospede>();
        }
    }
}
