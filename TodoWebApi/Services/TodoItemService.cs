using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebApi.Dtos;
using TodoWebApi.Models;
using TodoWebApi.Respositories;

namespace TodoWebApi.Services
{
    public class TodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;

        public TodoItemService(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }

        public async Task<List<TodoItemDto>> GetAll()
        {
            var entities = await _todoItemRepository.GetAllAsync();  // reikia async, nes is DB. Cia turime entities

            List<TodoItemDto> dtos = _mapper.Map<List<TodoItemDto>>(entities);
            // pasakom, kad is entities permappintu i List<TodoItemDto>

            return dtos;
        }

        public async Task<TodoItemDto> GetById(int id)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(id);

            TodoItemDto dto = _mapper.Map<TodoItemDto>(todoItem);

            return dto; 
        }

        public async Task Create(CreateTodoItemDto todoItemDto)
        {
            var entity = _mapper.Map<TodoItem>(todoItemDto);

            await _todoItemRepository.CreateAsync(entity);
        }

        public async Task Update(CreateTodoItemDto todoItemDto)
        {
            var entity = new TodoItem
            {
                Name = todoItemDto.Name
            };

            //Use automapper
            await _todoItemRepository.UpdateAsync(entity);
        }

        public async Task Remove(int id)
        {
            await _todoItemRepository.RemoveAsync(id);
        }
    }
}
