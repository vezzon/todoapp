using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using toDoApp.DataAccess;
using toDoApp.Models;

namespace toDoApp.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly TodoItemsContext _context;

        public TodoItemService(TodoItemsContext context)
        {
            _context = context;
        }
        public async Task<List<TodoItem>> GetAllItemsAsync() 
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<List<TodoItem>> AddTodoItemAsync(TodoItem item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return _context.TodoItems.ToList();
        }

        public async Task<TodoItem> UpdateItemAsync(TodoItem updatedItem)
        {
            var item = await _context.TodoItems.FirstAsync(x => x.Id == updatedItem.Id);
            item.Name = updatedItem.Name;
            item.IsComplete = updatedItem.IsComplete;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var existingItem = _context.TodoItems.First(x => x.Id == id);
            _context.TodoItems.Remove(existingItem);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> GetItemByIdAsync(int id) {
            return await _context.TodoItems.FirstOrDefaultAsync(i => i.Id == id);
        }

    }
}