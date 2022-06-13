using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Data;
using TodoWebApi.Exceptions;
using TodoWebApi.Models;

namespace TodoWebApi.Respositories
{
    public class TodoItemRepository
    {
        private readonly DataContext _dataContext;

        public TodoItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await _dataContext.TodoItems.ToListAsync();
        }

        public async Task Create (TodoItem todoItem)
        {
            _dataContext.TodoItems.Add(todoItem);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            var todoItem = await _dataContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (todoItem == null)
            {
                throw new ItemNotFoundException();
            }
            return todoItem;
        }

        public async Task Update(TodoItem todoItem)
        {
            var entity = new TodoItem
            {
                Name = todoItem.Name
            };

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var todoItem = await GetById(id);

            _dataContext.TodoItems.Remove(todoItem);
            await _dataContext.SaveChangesAsync();
        }
    }
}
