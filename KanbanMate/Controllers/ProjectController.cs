using KanbanMate.DataAccess;
using KanbanMate.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanbanMate.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Project> objProjectList = _db.projects;
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
                _db.projects.Add(obj);
                _db.SaveChanges();
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
            var projectFromDb = _db.projects.Single(p => p.Id == id);
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
                _db.projects.Update(obj);
                _db.SaveChanges();
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
            var projectFromDb = _db.projects.Single(p => p.Id == id);
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
                _db.projects.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
