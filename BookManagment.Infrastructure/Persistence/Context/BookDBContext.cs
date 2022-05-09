using BookManagment.Application.Interfaces.Context;
using BookManagment.Domain.Book;
using BookManagment.Domain.Log;
using BookManagment.Domain.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Infrastructure.Persistence.Context
{
    public class BookDBContext : DbContext, IBookDBContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<RequestResponseLog> RequestResponseLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .HasOne(x => x.BookDetails)
                .WithOne(x => x.Books)
                .HasForeignKey<BookDetails>(x=>x.BookID);
        }
    }
}
