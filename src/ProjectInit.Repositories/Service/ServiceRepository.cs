using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Common;
using ProjectInit.Repositories.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Service
{
    public class ServiceRepository : Repository<Core.Entities.Service, Guid>, IServiceRepository
    {
        public ServiceRepository(ProjectContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Core.Entities.Service>> GetServicesByHotelIdAsync(Guid hotelId)
        {
            return await _ctx.Services.Where(s => s.HotelId == hotelId).ToListAsync();
        }
        public async Task<Core.Entities.Service> GetServiceByServiceIdAsync(Guid serviceId)
        {
            return await _ctx.Services.SingleOrDefaultAsync(s => s.Id == serviceId);
        }

    }
}
