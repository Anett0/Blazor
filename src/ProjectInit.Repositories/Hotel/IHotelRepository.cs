using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Hotel
{
    public interface IHotelRepository : IRepository<Core.Entities.Hotel, Guid>
    {
        new Task<IEnumerable<Core.Entities.Hotel>> GetAllAsync();
        Task<Core.Entities.Hotel> GetByIdAsync(Guid id);
    }
}
