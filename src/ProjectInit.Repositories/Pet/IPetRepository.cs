using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Pet
{
    public interface IPetRepository : IRepository<Core.Entities.Pet, Guid>
    {
        Task<IEnumerable<Core.Entities.Pet>> PetsByHotelUserIdAsync(Guid id);
    }
}
