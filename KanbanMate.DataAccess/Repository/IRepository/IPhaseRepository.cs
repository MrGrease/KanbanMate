using KanbanMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KanbanMate.DataAccess.Repository.IRepository
{
    public interface IPhaseRepository : IRepository<Phase>
    {
        IEnumerable<Phase> Where(string id);

        void Update(Project obj);

        void Save();
    }
}
