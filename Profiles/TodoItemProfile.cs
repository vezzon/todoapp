using AutoMapper;
using toDoApp.Dtos;
using toDoApp.Models;

namespace toDoApp.Profiles
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItemCreateDto, TodoItem>();
        }
    }
}