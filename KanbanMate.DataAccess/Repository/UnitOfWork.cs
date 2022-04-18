using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanMate.DataAccess.Repository.IRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Project = new ProjectRepository(_db);
        }
        public IProjectRepository Project { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
