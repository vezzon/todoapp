using System.Collections.Generic;
using toDoApp.Models;

namespace toDoApp.Services
{
    public interface ITodoItemService
    {
        List<TodoItem> GetAllItems();
        TodoItem GetItemById(int id);
        List<TodoItem> AddTodoItem(TodoItem item);
        TodoItem UpdateItem(TodoItem updatedItem);
        void DeleteItem(int id);
    }
}