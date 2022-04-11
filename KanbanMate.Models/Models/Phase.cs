namespace KanbanMate.Models
{
    public class Phase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Project> Project { get; set; }   
    }
}
