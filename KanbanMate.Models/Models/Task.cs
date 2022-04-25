using System.ComponentModel.DataAnnotations;

namespace KanbanMate.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }  
        public string? Description { get; set; }
        public Phase? phase { get; set; }
    }
}
