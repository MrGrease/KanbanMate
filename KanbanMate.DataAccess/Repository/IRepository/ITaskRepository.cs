﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KanbanMate.Models;
namespace KanbanMate.DataAccess.Repository.IRepository
{
    public interface ITaskRepository : IRepository<Models.Task>
    {
        IEnumerable<Models.Task> Where(int id);

        void Update(Models.Task obj);

        void Save();
    }
}
