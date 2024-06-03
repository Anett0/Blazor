
using Microsoft.AspNetCore.Mvc;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Hotel;
using ProjectInit.Repositories.Review;
using ProjectInit.Repositories.Service;
using ProjectInit.Repositories.Users;

namespace ProjectInit.WebUI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IServiceRepository _serviceRepository;
        private readonly IReviewRepository _reviewRepository;

        public HotelController(IHotelRepository hotelRepository,
            IUserRepository userRepository,
            IWebHostEnvironment webHostEnvironment,
            IServiceRepository serviceRepository,
            IReviewRepository reviewRepository)
        {
            _serviceRepository = serviceRepository;
            _hotelRepository = hotelRepository;
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
            _reviewRepository = reviewRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _hotelRepository.GetAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            //ViewBag.Users = (await _userRepository
            //    .GetAllAsync())
            //    .Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

            return View(new Hotel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hotel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile is not null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileExt = Path.GetExtension(model.ImageFile.FileName);
                    var filePath = $"img/hotels/{model.Id}{fileExt}"; // Генеруємо унікальне ім'я файлу
                    string path = Path.Combine(wwwRootPath, filePath);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(fileStream);
                    }

                    model.ImagePath = filePath;
                }

                await _hotelRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            //ViewBag.Users = (await _userRepository
            //    .GetAllAsync())
            //    .Select(x => new SelectListItem { Text = x.FullName, Value = x.Id.ToString() }).ToList();

            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Hotel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    // Check if the user has uploaded a new image
                    if (model.ImageFile != null)
                    {
                        var fileExt = Path.GetExtension(model.ImageFile.FileName);
                        var filePath = $"img/hotels/{model.Id}{fileExt}";
                        string path = Path.Combine(wwwRootPath, filePath);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(fileStream);
                        }
                        model.ImagePath = filePath;
                        ViewBag.NewImage = true;
                        ViewBag.NewImagePath = filePath;
                    }
                    else
                    {
                        //// If no new image was uploaded, keep the old image
                        var imgPath = Request.Form["ImgPath"];
                        model.ImagePath = imgPath;
                    }

                    await _hotelRepository.UpdateAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.Message);

                    if (exception.InnerException != null)
                    {
                        ModelState.AddModelError("", exception.InnerException.Message);
                    }
                }
            }

            return View(model);
        }

        [HttpGet, ActionName("Description")]
        public async Task<IActionResult> DescriptionAsync()
        {
            return View(await _hotelRepository.GetAllAsync());
        }

        [HttpGet, ActionName("View")]
        public async Task<IActionResult> Details(Guid id)
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            hotel.Reviews = (ICollection<Review>)await _reviewRepository.ReviewsByHotelIdAsync(id);
            hotel.Services = (ICollection<Service>)await _serviceRepository.GetServicesByHotelIdAsync(id);
            return View(hotel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var hotel = await _hotelRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var reviewes = await _reviewRepository.ReviewsByHotelIdAsync(id);
            var services = await _serviceRepository.GetServicesByHotelIdAsync(id);
            foreach (var service in services)
            {
                await _serviceRepository.DeleteAsync(service.Id);
            }


            await _hotelRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }





    }
}