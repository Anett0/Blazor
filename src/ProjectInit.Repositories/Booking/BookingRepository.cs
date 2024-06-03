using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Booking
{
    public class BookingRepository : Repository<Core.Entities.Booking, Guid>, IBookingRepository
    {
        public BookingRepository(ProjectContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Core.Entities.Booking>> GetBookingsByUserAsync(Guid userId)
        {
            var bookings = await _ctx.Bookings.Where(b => b.UserId == userId).ToListAsync();

            return bookings;
        }
    }
}
