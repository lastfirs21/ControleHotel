using ControleHotel.Data.Dtos.Quarto;
using ControleHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;

namespace ControleHotel.Profiles
{
    public class QuartoProfile : Profile
    {
        public QuartoProfile()
        {
            CreateMap<CreateQuartoDto, Quarto>();
            CreateMap<Quarto, ReadQuartoDto>();
            CreateMap<UpdateQuartoDto, Quarto>();
        }
    }
}
