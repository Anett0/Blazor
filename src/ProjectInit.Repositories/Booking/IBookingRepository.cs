using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Booking
{
    public interface IBookingRepository : IRepository<Core.Entities.Booking, Guid>
    {
        Task<IEnumerable<Core.Entities.Booking>> GetBookingsByUserAsync(Guid userId);
    }
}
