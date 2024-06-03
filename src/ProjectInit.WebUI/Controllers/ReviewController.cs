using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Hotel;
using ProjectInit.Repositories.Review;
using ProjectInit.Repositories.Users;
using System.Globalization;

namespace ProjectInit.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public ReviewController(IReviewRepository reviewRepository, IUserRepository userRepository, UserManager<User> userManager, IHotelRepository hotelRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _reviewRepository = reviewRepository;
            _hotelRepository = hotelRepository;
        }

        // GET: Review/Create
        public IActionResult Create(int hotelId)
        {
            ViewBag.HotelId = hotelId;
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Review review)
        {
            var user = await _userManager.GetUserAsync(User);
            review.UserId = user.Id;
            review.UserName = user.FullName;
            review.Created = DateTime.Now;
            await _reviewRepository.CreateAsync(review);

            return RedirectToAction("View", "Hotel", new { id = review.HotelId });
        }

        // GET: Review/Edit/5
        public IActionResult Edit(Guid id)
        {
            var review = _reviewRepository.GetById(id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Review/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewRepository.UpdateAsync(review);
                return RedirectToAction("View", "Hotel", new { id = review.HotelId });
            }
            return RedirectToAction("View", "Hotel", new { id = review.HotelId });
        }

        //POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid hotelId, Guid reviewId)
        {

            await _reviewRepository.DeleteAsync(reviewId);

            return RedirectToAction("View", "Hotel", new { id = hotelId });
        }
    }
}
