using KanbanMate.DataAccess.Repository.IRepository;
using KanbanMate.Models;
using KanbanMate.Models.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KanbanMate.Controllers
{
    public class PhaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public IActionResult Create(int? id)
        {
            if(id == null)
            {
                return Redirect(HttpContext.Request.Headers["Referer"]);
            }
            PhaseVM ph = new PhaseVM();
            ph.projectId = (int)id;
            return View(ph);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateAsync(PhaseVM obj)
        {
            if (ModelState.IsValid)
            {
                Phase phase = new Phase();
                phase.Title = obj.phase.Title;
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var projectFromDb = _unitOfWork.Project.Where(userId, obj.projectId);
                if (projectFromDb == null)
                {
                    return Unauthorized();
                }
                phase.project = projectFromDb;
                _unitOfWork.phase.Add(phase);
                _unitOfWork.phase.Save();
                return RedirectToAction("Details","Project",new { id=obj.projectId });
            }
            else
            {
                return View(obj);
            }

        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var phase = _unitOfWork.phase.Get(id);
            _unitOfWork.phase.Remove(phase);
            List<int> ids = new List<int>();
            ids.Add(phase.Id);
            List<Models.Task> tasks = (List<Models.Task>)_unitOfWork.task.Where(ids);
            for(int i = 0; i < tasks.Count(); i++)
            {
                _unitOfWork.task.Remove(tasks[i]);
            }

            _unitOfWork.phase.Save();
            _unitOfWork.task.Save();
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }
    }
}
