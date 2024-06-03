using Microsoft.AspNetCore.Mvc;
using ProjectInit.Repositories.Pet;
using ProjectInit.Repositories.Users;

namespace ProjectInit.WebUI.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IPetRepository _petRepository;
        private readonly IUserRepository _userRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProjectsController(
            IPetRepository projectRepository,
            IUserRepository userRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _petRepository = projectRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _petRepository.GetAllAsync());
        }

        // GET: ProjectsController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _petRepository.GetAsync(id));
        }

        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
