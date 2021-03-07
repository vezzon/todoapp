using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace toDoApp.Models
{
    public class User
    {
        // TODO Add user role
        public int Id { get; set; }
        [MaxLength(255)]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<TodoItem> TodoItemsList { get; set; }
        
    }
}