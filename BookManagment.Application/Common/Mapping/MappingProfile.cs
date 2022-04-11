using AutoMapper;
using BookManagment.Application.Services.People.Query;
using BookManagment.Domain.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, GetAllPeopleItem>();
        }
    }
}
