using System.Collections.Generic;

namespace toDoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public User User { get; set; }
    }
}