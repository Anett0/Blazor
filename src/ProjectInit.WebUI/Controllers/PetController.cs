using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Pet;
using ProjectInit.Repositories.Users;

namespace ProjectInit.WebUI.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetRepository _petRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public PetController(IPetRepository petRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager, IUserRepository userRepository)
        {
            _petRepository = petRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            return View(await _petRepository.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View(new Pet());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pet model)
        {
            if (ModelState.IsValid)
            {
                // Отримуємо поточного користувача
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null)
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" }); // Перенаправляємо на сторінку входу, якщо користувач не увійшов
                }

                // Встановлюємо поточного користувача як власника пітомця
                model.UserId = currentUser.Id;

                if (model.ImageFile is not null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileExt = Path.GetExtension(model.ImageFile.FileName);
                    var filePath = $"img/pets/{model.Id}{fileExt}";
                    string path = Path.Combine(wwwRootPath, filePath);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(fileStream);
                    }

                    model.ImagePath = filePath;
                }
                model.Status = "Обробляється";

                await _petRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var pet = await _petRepository.GetAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            // Отримуємо поточного користувача
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                // Встановлюємо UserId книги на UserId поточного користувача
                pet.UserId = currentUser.Id;
            }

            return View(pet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Pet model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ImageFile is not null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;

                        var fileExt = Path.GetExtension(model.ImageFile.FileName);
                        var filePath = $"img/pets/{model.Id}{fileExt}";
                        string path = Path.Combine(wwwRootPath, filePath);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(fileStream);
                        }

                        model.ImagePath = filePath;
                    }
                    await _petRepository.UpdateAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View(model);
        }

        [HttpGet, ActionName("View")]
        public async Task<IActionResult> Details(Guid id)
        {
            var pet = await _petRepository.GetAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            if (pet.UserId != null)
            {
                var user = await _userRepository.GetAsync((Guid)pet.UserId);

            }

            return View(pet);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var pet = await _petRepository.GetAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _petRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Accept")]
        public async Task<IActionResult> Accept(Guid id)
        {
            var pet = await _petRepository.GetAsync(id);
            if (pet != null)
            {
                pet.Status = "Прийнято";
                await _petRepository.UpdateAsync(pet);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Reject")]
        public async Task<IActionResult> Reject(Guid id)
        {
            var pet = await _petRepository.GetAsync(id);
            if (pet != null)
            {
                pet.Status = "Відхилено";
                await _petRepository.UpdateAsync(pet);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
