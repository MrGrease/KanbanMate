using KanbanMate.DataAccess;
using KanbanMate.DataAccess.Repository.IRepository;
using KanbanMate.Models;
using KanbanMate.Models.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KanbanMate.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;


        public ProjectController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<Project> objProjectList = _unitOfWork.Project.Where(userId);
            return View(objProjectList);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateAsync(Project obj)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.GetUserAsync(User);
                obj.users.Add(user);
                _unitOfWork.Project.Add(obj);
                _unitOfWork.Project.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projectFromDb = _unitOfWork.Project.GetFirstOrDefault(p => p.Id == id);
            if (projectFromDb == null)
            {
                return NotFound();
            }

            return View(projectFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(Project obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Project.Update(obj);
                _unitOfWork.Project.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projectFromDb = _unitOfWork.Project.GetFirstOrDefault(p => p.Id == id);
            if (projectFromDb == null)
            {
                return NotFound();
            }

            return View(projectFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeletePost(Project obj)
        {
            _unitOfWork.Project.Remove(obj);
            _unitOfWork.Project.Save();
                return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projectFromDb = _unitOfWork.Project.Where(userId,id);
            if (projectFromDb == null)
            {
                return Unauthorized();
            }

            List<Phase> phases = _unitOfWork.phase.Where(id);
            List<int> phaseIds=new List<int>();
            for(int i=0;i<phases.Count();i++)
            {
                phaseIds.Add(phases[i].Id);
            }

            List<Models.Task> tasksList = (List<Models.Task>)_unitOfWork.task.Where(phaseIds);
            Dictionary<int, List<Models.Task>> tasks = new Dictionary<int, List<Models.Task>>();
            for (int i = 0; i < phaseIds.Count(); i++)
            {
               tasks.Add(phaseIds[i], new List<Models.Task>()); 
            }
            for (int i = 0; i < tasksList.Count(); i++)
            {
                tasks[tasksList[i].phase.Id].Add(tasksList[i]);
            }
            ProjectVM VM = new ProjectVM();
            VM.Project= projectFromDb;
            VM.Phases = (List<Phase>)phases;
            VM.Tasks = tasks;

            return View(VM);
        }
    }
}
