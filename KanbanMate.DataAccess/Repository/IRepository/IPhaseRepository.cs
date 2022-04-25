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
        List<Phase> Where(int id);

        Phase Get(int id);
        void Update(Phase obj);

        void Save();
        void Remove(Phase ph);
    }
}
