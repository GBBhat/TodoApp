using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace TaskAPI.Models
{
    
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public Boolean Completed { get; set; }

    }
}
