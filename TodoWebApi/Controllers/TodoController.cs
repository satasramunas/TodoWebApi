using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApi.Dtos;
using TodoWebApi.Exceptions;
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _todoItemService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _todoItemService.GetById(id));
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTodoItemDto todoItem)
        {
            await _todoItemService.Create(todoItem);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(CreateTodoItemDto todoItem)
        {
            await _todoItemService.Update(todoItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)    //grazina tik Task, tada paprasciau. Galima grazinti ir Lista.
        {
            try
            {
                await _todoItemService.Remove(id);

                return NoContent();
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            //return await _todoItemService.GetAll();
        }
    }
}
