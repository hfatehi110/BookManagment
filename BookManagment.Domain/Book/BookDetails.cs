using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagment.Domain.Book
{
    public class BookDetails
    {
        [Required, Key]
        public int BookDetailID { get; set; }
        public string Publisher { get; set; }
        public string Year{ get; set; }
        public int PageCount { get; set; }
        public int BookID { get; set; }
        public Books Books { get; set; }
    }
}
