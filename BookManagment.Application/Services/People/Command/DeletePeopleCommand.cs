using BookManagment.Application.Interfaces;
using BookManagment.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Application.Services.People.Command
{

    public class DeletePeopleCommand : IRequestHandler<int, bool>
    {
        private readonly IBookDBContext _db;

        public DeletePeopleCommand(IBookDBContext db)
        {
            _db = db;
        }

        public async Task<bool> Handler(int request, CancellationToken cancellationToken)
        {
            var personItem = _db.People.FirstOrDefault(x => x.PersonID == request);
            if (personItem == null) return false;
            _db.People.Remove(personItem);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
