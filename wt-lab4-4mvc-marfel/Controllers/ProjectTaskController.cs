using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_marfel.Models;

namespace wt_lab4_4mvc_marfel.Controllers
{
    public class ProjectTaskController : Controller
    {
        // Статический список для хранения данных в памяти (имитация БД)
        private static List<ProjectTask> _tasks = new List<ProjectTask>
        {
            new ProjectTask { Id = 1, Title = "Разработать API", Assignee = "Иван", Priority = "High", IsCompleted = false },
            new ProjectTask { Id = 2, Title = "Написать тесты", Assignee = "Анна", Priority = "Medium", IsCompleted = true },
            new ProjectTask { Id = 3, Title = "Обновить документацию", Assignee = "Петр", Priority = "Low", IsCompleted = false }
        };

        // GET: /ProjectTask/Index
        public IActionResult Index()
        {
            return View(_tasks); // Передаем список задач в View
        }

        // GET: /ProjectTask/Details/1
        public IActionResult Details(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }

        // GET: /ProjectTask/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /ProjectTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
                _tasks.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: /ProjectTask/Edit/1
        public IActionResult Edit(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: /ProjectTask/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
                if (existingTask != null)
                {
                    existingTask.Title = task.Title;
                    existingTask.Assignee = task.Assignee;
                    existingTask.Priority = task.Priority;
                    existingTask.IsCompleted = task.IsCompleted;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
    }
}