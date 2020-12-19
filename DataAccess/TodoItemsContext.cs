using Microsoft.EntityFrameworkCore;
using toDoApp.Models;

namespace toDoApp.DataAccess
{
    public class TodoItemsContext : DbContext
    {
        public TodoItemsContext(DbContextOptions<TodoItemsContext> options) : base(options) { }
        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}