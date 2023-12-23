using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public Book bgBook { get; set; }

        public int GenreId { get; set; }
        public Genre bgGenre { get; set; }
    }
}
