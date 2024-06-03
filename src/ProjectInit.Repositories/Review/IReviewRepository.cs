using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Review
{
    public interface IReviewRepository : IRepository<Core.Entities.Review, Guid>
    {
        Task<IEnumerable<Core.Entities.Review>> GetById(Guid id);

        Task<IEnumerable<Core.Entities.Review>> ReviewsByHotelIdAsync(Guid id);
    }
}
