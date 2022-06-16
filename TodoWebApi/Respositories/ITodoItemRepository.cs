using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Models;

namespace TodoWebApi.Respositories
{
    public interface ITodoItemRepository
    {
        Task CreateAsync(TodoItem todoItem);
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task UpdateAsync(TodoItem todoItem);
    }
}
