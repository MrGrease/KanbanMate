using KanbanMate.DataAccess;
using KanbanMate.DataAccess.Repository.IRepository;
using KanbanMate.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanbanMate.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Project> objProjectList = _unitOfWork.Project.GetAll();
            return View(objProjectList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public IActionResult DeletePost(Project obj)
        {
            _unitOfWork.Project.Remove(obj);
            _unitOfWork.Project.Save();
                return RedirectToAction("Index");
        }
    }
}
