using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace toDoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public User User { get; set; }
    }
}