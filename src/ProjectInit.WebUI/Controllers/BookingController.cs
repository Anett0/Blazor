using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Booking;
using ProjectInit.Repositories.Hotel;
using ProjectInit.Repositories.Pet;
using ProjectInit.Repositories.Service;
using ProjectInit.Repositories.Users;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectInit.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository? _bookingRepository;
        private readonly IHotelRepository? _hotelRepository;
        private readonly IPetRepository? _petRepository;
        private readonly IUserRepository? _userRepository;
        private readonly IServiceRepository? _serviceRepository;
        private readonly UserManager<User> _userManager;

        public BookingController(IBookingRepository bookingRepository,
            IPetRepository petRepository,
            IHotelRepository hotelRepository,
            IUserRepository userRepository,
            IServiceRepository serviceRepository, 
            UserManager<User> userManager)
        {
            _bookingRepository = bookingRepository;
            _hotelRepository = hotelRepository;
            _petRepository = petRepository;
            _userRepository = userRepository;
            _serviceRepository = serviceRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            var bookings = await _bookingRepository.GetBookingsByUserAsync(userId);

            ViewData["HotelRepository"] = _hotelRepository;

            return View(bookings);
        }

        public async Task<IActionResult> AdminP()
        {
            var bookings = await _bookingRepository.GetAllAsync();

            ViewData["HotelRepository"] = _hotelRepository;

            return View(bookings);
        }

        [HttpGet, ActionName("Rent")]
        public async Task<IActionResult> Rent(Guid hotelId, Guid serviceId)
        {
            ViewBag.HotelId = hotelId;

            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var services = await _serviceRepository.GetServiceByServiceIdAsync(serviceId);
            var pets = (ICollection<Pet>)await _petRepository.PetsByHotelUserIdAsync(userId);

            var acceptedPets = pets.Where(p => p.Status == "Прийнято").ToList();

            var booking = new Booking { HotelId = hotelId, Pet = acceptedPets, Services = new[] { services } };

            return View(booking);
        }

        [HttpPost, ActionName("Rent")]
        public async Task<IActionResult> Rent(Booking booking, Guid hotelId)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);
            }

            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            booking.UserId = userId;
            booking.HotelId = hotelId;
            booking.Status = "У черзі..."; // set the status to "Обробляється"

            await _bookingRepository.CreateAsync(booking);

            return RedirectToAction("View", "Hotel", new { id = hotelId }); // redirect to the booking index page
        }

        [HttpPost, ActionName("BookingCenceled")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookingCenceled(Guid id)
        {
            var booking = await _bookingRepository.GetAsync(id);
            if (booking != null)
            {
                booking.Status = "Відмінено користувачем...";
                await _bookingRepository.UpdateAsync(booking);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bookingRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, string status)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var existingBooking = await _bookingRepository.GetAsync(id);
            if (existingBooking != null)
            {
                existingBooking.Status = status;
                await _bookingRepository.UpdateAsync(existingBooking);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
