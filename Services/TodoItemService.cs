using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using toDoApp.DataAccess;
using toDoApp.Dtos;
using toDoApp.Models;

namespace toDoApp.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly TodoItemsContext _db;
        private readonly IMapper _mapper;

        public TodoItemService(TodoItemsContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<TodoItem>> GetAllItemsAsync() 
        {
            return await _db.TodoItems.ToListAsync();
        }

        public async Task<List<TodoItem>> AddTodoItemAsync(TodoItemCreateDto newItem)
        {
            var item = _mapper.Map<TodoItem>(newItem);
            _db.Add(item);
            await _db.SaveChangesAsync();
            return _db.TodoItems.ToList();
        }

        public async Task<TodoItem> UpdateItemAsync(TodoItem updatedItem)
        {
            var item = await _db.TodoItems.FirstAsync(x => x.Id == updatedItem.Id);
            item.Name = updatedItem.Name;
            item.IsComplete = updatedItem.IsComplete;
            _db.Update(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var existingItem = _db.TodoItems.First(x => x.Id == id);
            _db.TodoItems.Remove(existingItem);
            await _db.SaveChangesAsync();
        }

        public async Task<TodoItem> GetItemByIdAsync(int id) {
            return await _db.TodoItems.FirstOrDefaultAsync(i => i.Id == id);
        }

    }
}