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
    public class PhaseRepository : Repository<Phase>, IPhaseRepository
    {
        private ApplicationDbContext _db;
        public PhaseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Phase obj)
        {
            _db.phases.Update(obj);
        }

        public IEnumerable<Phase> Where(int id)
        {
            return _db.phases.Where(x =>x.project.Id == id).ToList();
        }
    }
}
