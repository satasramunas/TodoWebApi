using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Dtos;
using TodoWebApi.Models;

namespace TodoWebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemDto>().ReverseMap();
            CreateMap<CreateTodoItemDto, TodoItem>();
        }
    }
}
