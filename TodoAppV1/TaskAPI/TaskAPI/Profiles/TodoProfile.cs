using AutoMapper;
using TaskAPI.Dtos;
using TaskAPI.Models;

namespace TaskAPI.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile() {
            CreateMap<Todo, TodoDto>();
            CreateMap<TodoDto, Todo>();
        }

    }
}
