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
        public async Task<ActionResult> Get()
        {
            return Ok(await _itemService.GetAllItemsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingle(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> AddTodoItem(TodoItem item) 
        {
            return Ok(await _itemService.AddTodoItemAsync(item));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTodoItem(TodoItem item)
        {
            var existingItem = _itemService.GetItemByIdAsync(item.Id);
            if (await existingItem == null)
            {
                return NotFound();
            }
            return Ok(await _itemService.UpdateItemAsync(item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(int id)
        {
            var existingItem = _itemService.GetItemByIdAsync(id);
            if (await existingItem == null)
            {
                return NotFound();
            }

            await _itemService.DeleteItemAsync(id);
            return Ok();
        }
    }
}