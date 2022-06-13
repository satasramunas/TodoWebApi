using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Data;
using TodoWebApi.Dtos;
using TodoWebApi.Exceptions;
using TodoWebApi.Models;
using TodoWebApi.Respositories;

namespace TodoWebApi.Services
{
    public class TodoItemService
    {
        private readonly TodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public TodoItemService(TodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public async Task<List<TodoItemDto>> GetAll()
        {
            var entities = await _todoItemRepository.GetAll();  // reikia async, nes is DB. Cia turime entities

            List<TodoItemDto> dtos = _mapper.Map<List<TodoItemDto>>(entities);
            // pasakom, kad is entities permappintu i List<TodoItemDto>

            return dtos;
        }

        public async Task<TodoItemDto> GetById(int id)
        {
            var todoItem = await _todoItemRepository.GetById(id);

            TodoItemDto dto = _mapper.Map<TodoItemDto>(todoItem);

            return dto; 
        }

        public async Task Create(CreateTodoItemDto todoItemDto)
        {
            var entity = new TodoItem
            {
                Name = todoItemDto.Name
            };

            await _todoItemRepository.Create(entity);
        }

        public async Task Update(CreateTodoItemDto todoItemDto)
        {
            var entity = new TodoItem
            {
                Name = todoItemDto.Name
            };
            await _todoItemRepository.Update(entity);
        }

        public async Task Remove(int id)
        {
            await _todoItemRepository.Remove(id);
        }
    }
}
