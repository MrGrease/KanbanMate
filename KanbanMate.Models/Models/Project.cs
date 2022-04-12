namespace KanbanMate.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Description { get; set; }

        public ICollection<AppUser> users { get; set; }
    }
}
