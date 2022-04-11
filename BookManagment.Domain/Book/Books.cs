using BookManagment.Domain.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Domain.Book
{
    public class Books
    {
        [Required, Key]
        public int BookID { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

    
        public BookDetails BookDetails { get; set; }

        public int PersonID { get; set; }
        public Person MyProperty { get; set; }
    }
}
