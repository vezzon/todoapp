using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using toDoApp.Models;
using toDoApp.Services;

namespace toDoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemService _itemService;

        public TodoController(ITodoItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_itemService.GetAllItems());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(_itemService.GetItemById(id));
        }

        [HttpPost]
        public IActionResult AddTodoItem(TodoItem item) 
        {
            return Ok(_itemService.AddTodoItem(item));
        }

        [HttpPut]
        public IActionResult UpdateTodoItem(TodoItem item)
        {
            var existingItem = _itemService.GetItemById(item.Id);
            if (existingItem == null)
            {
                return NotFound();
            }
            return Ok(_itemService.UpdateItem(item));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(int id)
        {
            var existingItem = _itemService.GetItemById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            
            _itemService.DeleteItem(id);

            return Ok();
        }
    }
}