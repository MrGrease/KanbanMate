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
    }
}
