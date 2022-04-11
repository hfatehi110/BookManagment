using BookManagment.Domain.Book;
using BookManagment.Domain.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Application.Interfaces.Context
{
    public interface IBookDBContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Books> Books { get; set; }
        DbSet<BookDetails> BookDetails { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
