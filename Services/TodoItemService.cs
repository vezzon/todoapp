using System.Collections.Generic;
using System.Linq;
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
        public List<TodoItem> GetAllItems() 
        {
            return _context.TodoItems.ToList();
        }

        public List<TodoItem> AddTodoItem(TodoItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return _context.TodoItems.ToList();
        }

        public TodoItem UpdateItem(TodoItem updatedItem)
        {
            var item = _context.TodoItems.First(x => x.Id == updatedItem.Id);
            item.Name = updatedItem.Name;
            item.IsComplete = updatedItem.IsComplete;
            _context.Update(item);
            _context.SaveChanges();
            return item;
        }

        public void DeleteItem(int id)
        {
            var existingItem = _context.TodoItems.First(x => x.Id == id);
            _context.TodoItems.Remove(existingItem);
            _context.SaveChanges();
        }

        public TodoItem GetItemById(int id) {
            return _context.TodoItems.FirstOrDefault(i => i.Id == id);
        }

    }
}