using ControleHotel.Data.Dtos.Hospedagem;
using ControleHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;

namespace ControleHotel.Profiles
{
    public class HospedagemProfile : Profile
    {
        public HospedagemProfile()
        {
            CreateMap<CreateHospedagemDto, Hospedagem>();
            CreateMap<Hospedagem, ReadHospedagemDto>();
            CreateMap<UpdateHospedagemDto, Hospedagem>();
        }
    }
}
