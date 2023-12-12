using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public Boolean Completed { get; set; }
    }
}
