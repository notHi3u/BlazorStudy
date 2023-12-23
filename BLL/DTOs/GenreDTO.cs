using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Genre name is required.")]
        public string Name { get; set; }
    }
}
