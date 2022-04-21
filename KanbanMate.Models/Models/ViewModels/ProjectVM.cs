using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KanbanMate.Models.Models.ViewModels
{
    public class ProjectVM
    {
        public Project Project { get; set; }

        public List<Phase> Phases { get; set; }

        public Dictionary<int, List<Task>> Tasks { get; set; }
    }
}
