using KanbanMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanMate.DataAccess.Repository.IRepository
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> Where(string id);

        Project Where(string id,int projectid);
        void Update(Project obj);

        void Save();
    }
}
