using Microsoft.AspNetCore.Mvc;

namespace KanbanMate.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
