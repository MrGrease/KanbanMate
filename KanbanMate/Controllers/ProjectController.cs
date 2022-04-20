using KanbanMate.DataAccess;
using KanbanMate.DataAccess.Repository.IRepository;
using KanbanMate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KanbanMate.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;


        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        public IActionResult Create(Project obj)
        {
            if (ModelState.IsValid)
            {
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
    }
}
