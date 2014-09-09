using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MySQL_Books.Models
{
    class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ISBN { get; set; }

        public Book(string bookName, string authorName, DateTime published, int isbn)
        {
            this.BookName = bookName;
            this.AuthorName = authorName;
            this.PublishedDate = published;
            this.ISBN = isbn;
        }
    }
}
