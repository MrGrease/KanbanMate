using Microsoft.AspNetCore.Identity;

namespace KanbanMate.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Project> projects { get; set; }  
    }
}
