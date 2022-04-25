using System.ComponentModel.DataAnnotations;

namespace KanbanMate.Models
{
    public class Phase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public Project? project{ get; set; }   
    }
}
