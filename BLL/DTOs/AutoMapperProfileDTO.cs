using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AutoMapperProfileDTO: Profile
    {
        public AutoMapperProfileDTO() {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
        }

    }
}
