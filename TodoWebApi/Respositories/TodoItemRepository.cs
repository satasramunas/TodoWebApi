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
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly DataContext _dataContext;

        public TodoItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _dataContext.TodoItems.ToListAsync();
        }
        
        public async Task<TodoItem> GetByIdAsync(int id)
        {
            var todoItem = await _dataContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if (todoItem == null)
            {
                throw new ItemNotFoundException();
            }
            return todoItem;
        }

        public async Task CreateAsync(TodoItem todoItem)
        {
            _dataContext.TodoItems.Add(todoItem);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoItem todoItem)
        {
            var entity = new TodoItem
            {
                Name = todoItem.Name
            };

            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var todoItem = await GetByIdAsync(id);

            _dataContext.TodoItems.Remove(todoItem);
            await _dataContext.SaveChangesAsync();
        }
    }
}
