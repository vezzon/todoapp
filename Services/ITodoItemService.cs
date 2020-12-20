using System.Collections.Generic;
using System.Threading.Tasks;
using toDoApp.Dtos;
using toDoApp.Models;

namespace toDoApp.Services
{
    public interface ITodoItemService
    {
        Task<List<TodoItem>> GetAllItemsAsync();
        Task<TodoItem> GetItemByIdAsync(int id);
        Task<List<TodoItem>> AddTodoItemAsync(TodoItemCreateDto item);
        Task<TodoItem> UpdateItemAsync(TodoItem updatedItem);
        Task DeleteItemAsync(int id);
    }
}