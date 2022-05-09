
using AutoMapper;
using BookManagment.Application.Services.Log.Query;
using BookManagment.Application.Services.People.Query;
using BookManagment.Domain.Log;
using BookManagment.Domain.People;


namespace BookManagment.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, GetAllPeopleItem>();
            CreateMap<RequestResponseLog, GetAllLogQueryItem>();
        }
    }
}
