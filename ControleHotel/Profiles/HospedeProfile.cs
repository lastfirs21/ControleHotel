using AutoMapper;
using ControleHotel.Data.Dtos.Hospede;
using ControleHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleHotel.Profiles
{
    public class HospedeProfile : Profile
    {
        public HospedeProfile()
        {
            CreateMap<CreateHospedeDto, Hospede>();
            CreateMap<Hospede, ReadHospedeDto>();
            CreateMap<UpdateHospedeDto, Hospede>();
        }
    }
}
