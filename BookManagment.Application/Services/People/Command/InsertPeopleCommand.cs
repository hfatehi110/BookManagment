using BookManagment.Application.Interfaces;
using BookManagment.Application.Interfaces.Context;
using BookManagment.Domain.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Application.Services.People.Command.InsertPeople
{   
    public class PeopleItemCommand
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Tell{ get; set; }
    }
    public class InsertPeopleCommand : IRequestHandler<PeopleItemCommand,int>
    {
        private readonly IBookDBContext _db;
        public InsertPeopleCommand(IBookDBContext db)
        {
            _db = db;
        }
        public async Task<int> Handler(PeopleItemCommand request, CancellationToken cancellationToken)
        {
            var NewPeople = new Person
            {
                Name = request.Name,
                Family = request.Family,
                Tell = request.Tell
            };
            _db.People.Add(NewPeople);
            return await _db.SaveChangesAsync();
        }
    }
}
