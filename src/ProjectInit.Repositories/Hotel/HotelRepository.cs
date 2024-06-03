using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Repositories.Booking;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Hotel
{
    public class HotelRepository : Repository<Core.Entities.Hotel, Guid>, IHotelRepository
    {
        public HotelRepository(ProjectContext ctx) : base(ctx) { }

        public new async Task<IEnumerable<Core.Entities.Hotel>> GetAllAsync()
        {
            return await _ctx.Hotels
              .Include(h => h.Reviews)
              .ToListAsync();
        }
        public async Task<Core.Entities.Hotel> GetByIdAsync(Guid id)
        {
            return await _ctx.Hotels.FindAsync(id);
        }
    }
}
