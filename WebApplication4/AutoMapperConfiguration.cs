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
            CreateMap<Tasks, TasksListViewModel>();
            CreateMap<TaskModel, Tasks>();
            CreateMap<Tasks, TaskModel>();
            CreateMap<TaskHistoric, HistoricTaskModel>();
            CreateMap<Tasks, TaskModelEdit>();
            CreateMap<TaskModelEdit, Tasks>();
        }
    }
}
