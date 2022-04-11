using System.ComponentModel.DataAnnotations;

namespace KanbanMate.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Description { get; set; }
    }
}
