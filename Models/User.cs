using System.Collections.Generic;

namespace toDoApp.Models
{
    public class User
    {
        // TODO Add user role
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<TodoItem> TodoItemsList { get; set; }
        
    }
}