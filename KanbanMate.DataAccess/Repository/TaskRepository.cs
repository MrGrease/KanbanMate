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
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        private ApplicationDbContext _db;
        public TaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Models.Task obj)
        {
            _db.tasks.Update(obj);
        }

        public IEnumerable<Models.Task> Where(List<int> ids)
        {
            return _db.tasks.Where(x =>
                    ids.Contains(x.phase.Id)).ToList();
        }

    }
}
