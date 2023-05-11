using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    public class SickProfile : Profile
    {
        public SickProfile()
        {
            CreateMap<Sick, SickDTO>().ReverseMap();

        }
    }
}
