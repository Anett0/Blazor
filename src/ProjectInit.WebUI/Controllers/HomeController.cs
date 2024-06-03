using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Common;
using ProjectInit.Repositories.Users;
using ProjectInit.WebUI.Models;
using System.Diagnostics;

namespace ProjectInit.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Hotel, Guid> repository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Hotel, Guid> _hotelRepository;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager,
            IRepository<Hotel, Guid> repository, IUserRepository userRepository, IRepository<Hotel, Guid> hotelRepository)
        {
            _userManager = userManager;
            _logger = logger;
            this.repository = repository;
            _userRepository = userRepository;
            _hotelRepository = hotelRepository;
        }

        public IActionResult Index()
        {
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View(repository.GetAllAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
