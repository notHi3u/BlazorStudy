using BlazorApp4v6.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using AutoMapper;
using BLL.DTOs;

namespace BlazorApp4v6.Shared.DTOs
{
    public class AutoMapperProfileUI : Profile
    {
        public AutoMapperProfileUI()
        {
            CreateMap<BookDTO, BookUI>();
            CreateMap<BookUI, BookDTO>();
            CreateMap<GenreUI, GenreDTO>();
            CreateMap<GenreDTO, GenreUI>();
        }
    }
}
