using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Common;
using ProjectInit.Repositories.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Review
{
    public class ReviewRepository : Repository<Core.Entities.Review, Guid>, IReviewRepository
    {
        public ReviewRepository(ProjectContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Core.Entities.Review>> GetById(Guid id)
        {
            return await _ctx.Reviews.Where(r => r.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Core.Entities.Review>> ReviewsByHotelIdAsync(Guid hotelId)
        {
            var reviews = await _ctx.Reviews.Where(r => r.HotelId == hotelId).ToListAsync();

            return reviews;
        }
    }
}
