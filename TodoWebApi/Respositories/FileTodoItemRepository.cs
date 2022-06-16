using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Models;

namespace TodoWebApi.Respositories
{
    public class FileTodoItemRepository : ITodoItemRepository
    {
        private readonly string _fileName = "data.json";

        public async Task CreateAsync(TodoItem todoItem)
        {
            string dataText = await File.ReadAllTextAsync(_fileName);

            var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(dataText);

            todoItems.Add(todoItem);

            var updatedDataText = JsonConvert.SerializeObject(todoItems);

            await File.WriteAllTextAsync(_fileName, updatedDataText);
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            string dataText = await File.ReadAllTextAsync(_fileName);

            var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(dataText);

            return todoItems;
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            string dataText = await File.ReadAllTextAsync(_fileName);

            var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(dataText);
        
            return todoItems.FirstOrDefault(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            string dataText = await File.ReadAllTextAsync(_fileName);

            var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(dataText);

            todoItems = todoItems.Where(si => si.Id != id).ToList();

            var updatedDataText = JsonConvert.SerializeObject(todoItems);
        }

        public Task UpdateAsync(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
