using KanbanMate.DataAccess.Repository.IRepository;
using KanbanMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KanbanMate.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private ApplicationDbContext _db;
        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Project obj)
        {
            _db.projects.Update(obj);
        }

        public IEnumerable<Project> Where(string userId)
        {
            return _db.projects.Where(x => x.users.Any(x =>
                    x.Id == userId)).ToList();
        }
        public Project Where(string userId,int projectId)
        {
            return _db.projects.Where(x => x.users.Any(x =>
                    x.Id == userId)).Where(p => p.Id == projectId).ToList().FirstOrDefault();
        }
    }
}
