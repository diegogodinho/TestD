using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Domain.Entities.Tasks, TagListViewModel>();
            CreateMap<TagModel, Tasks>();
            CreateMap<Tasks, TagModel>();
        }
    }
}
