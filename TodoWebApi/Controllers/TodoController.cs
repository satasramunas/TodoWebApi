using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Models;
using TodoWebApi.Services;

namespace TodoWebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoItemService _todoItemService;

        public TodoController(TodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet]
        public async Task<List<TodoItem>> GetAll()
        {
            return await _todoItemService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<TodoItem> GetById(int id)
        {
            return await _todoItemService.GetById(id);
        }

        [HttpPost]
        public async Task Create(TodoItem todoItem)
        {
            await _todoItemService.Add(todoItem);
        }

        [HttpPut]
        public async Task Update(TodoItem todoItem)
        {
            await _todoItemService.Update(todoItem);
        }

        [HttpDelete("{id}")]
        public async Task Remove(int id)    //grazina tik Task, tada paprasciau. Galima grazinti ir Lista.
        {
            await _todoItemService.Remove(id);
            //return await _todoItemService.GetAll();
        }
    }
}
