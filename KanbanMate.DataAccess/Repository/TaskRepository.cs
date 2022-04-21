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
    public class TaskRepository : ITaskRepository
    {
        public void Add(Models.Task entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Models.Task GetFirstOrDefault(Expression<Func<Models.Task, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Remove(Models.Task entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Models.Task> entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Project obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phase> Where(string id)
        {
            throw new NotImplementedException();
        }
    }
}
