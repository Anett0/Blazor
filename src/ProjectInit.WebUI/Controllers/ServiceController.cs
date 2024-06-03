using Microsoft.AspNetCore.Mvc;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Hotel;
using ProjectInit.Repositories.Service;

namespace ProjectInit.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IHotelRepository _hotelRepository;

        public ServiceController(IServiceRepository serviceRepository, IHotelRepository hotelRepository)
        {
            _serviceRepository = serviceRepository;
            _hotelRepository = hotelRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _serviceRepository.GetAllAsync());
        }

        [HttpGet, ActionName("Create")]
        public async Task<IActionResult> Create(Guid hotelId)
        {
            ViewBag.HotelId = hotelId;
            var service = new Service { HotelId = hotelId };

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service model)
        {
            var hotelId = ModelState["HotelId"].AttemptedValue;
            if (ModelState.IsValid)
            {
                await _serviceRepository.CreateAsync(model);
                string url = Url.Action("View", "Hotel", new { id = hotelId });
                return Redirect(url);

            }


            if (Guid.TryParse(hotelId, out Guid hotelGuid))
            {
                ViewBag.HotelId = hotelGuid;
                model.HotelId = hotelGuid;
            }

            return View(model);
        }

        [HttpGet, ActionName("Edit")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var service = await _serviceRepository.GetAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Service model)
        {
            var hotelId = ModelState["HotelId"].AttemptedValue;
            if (ModelState.IsValid)
            {
                await _serviceRepository.UpdateAsync(model);

                return RedirectToAction("View", "Hotel", new { id = model.HotelId });
            }

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid hotelId, Guid serviceId)
        {
            await _serviceRepository.DeleteAsync(serviceId);
            var redirectUrl = Url.Action("View", "Hotel", new { id = hotelId }, Request.Scheme);
            return Redirect(redirectUrl);
        }

        



    }


}

