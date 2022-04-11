using AutoMapper;
using BookManagment.Application.Interfaces;
using BookManagment.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Application.Services.People.Query
{
    public class GetAllPeopleItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Tell { get; set; }
        public string FullName { get { return $"{Name} {Family}"; } set { FullName = value; } }

    }
    public class GetAllPeopleQuery : IRequestHandler<GetAllPeopleItem>
    {
        private readonly IBookDBContext _db;
        private readonly IMapper _mapper;
        public GetAllPeopleQuery(IBookDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public List<GetAllPeopleItem> Handler(CancellationToken cancellationToken)
        {
            var Items = _db.People.ToList();
            return  _mapper.Map<List<GetAllPeopleItem>>(Items);
        }
    }
}
