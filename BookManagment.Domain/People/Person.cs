using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagment.Domain.Book;

namespace BookManagment.Domain.People
{
    public class Person
    {
        [Required,Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Tell { get; set; }

        public int BooksID { get; set; }
        public IEnumerable<Books> Books { get; set; }
    }
}
