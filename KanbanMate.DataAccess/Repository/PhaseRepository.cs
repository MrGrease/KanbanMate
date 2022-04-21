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
    public class PhaseRepository : IPhaseRepository
    {
        public void Add(Phase entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phase> GetAll()
        {
            throw new NotImplementedException();
        }

        public Phase GetFirstOrDefault(Expression<Func<Phase, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Remove(Phase entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Phase> entity)
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
