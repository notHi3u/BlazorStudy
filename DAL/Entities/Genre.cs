﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre name is required.")]
        public string Name { get; set; }

        // Navigation property for BookGenres
        public List<BookGenre>? BookGenres { get; set; }
    }
}
