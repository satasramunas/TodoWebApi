using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Data;
using TodoWebApi.Models;

namespace TodoWebApi.Services
{
    public class TodoItemService
    {
        private readonly DataContext _dataContext;

        public TodoItemService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await _dataContext.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await _dataContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(TodoItem todoItem)
        {
            _dataContext.TodoItems.Add(todoItem);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update (TodoItem todoItem)
        {
            _dataContext.Update(todoItem);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            TodoItem todoItem = await GetById(id);

            _dataContext.TodoItems.Remove(todoItem);
            await _dataContext.SaveChangesAsync();
        }
    }
}
