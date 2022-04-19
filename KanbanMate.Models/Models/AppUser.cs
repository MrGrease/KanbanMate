using Microsoft.AspNetCore.Identity;

namespace KanbanMate.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<Project> projects { get; set; }  
    }
}
