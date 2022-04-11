using Microsoft.AspNet.Identity.EntityFramework;

namespace KanbanMate.Models
{
    public class Project
    {
        public Project()
        {
            this.Users = new HashSet<IdentityUser>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int Description { get; set; }

        public ICollection<IdentityUser> Users { get; set; }
    }
}
