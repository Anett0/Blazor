using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Service
{
    public interface IServiceRepository : IRepository<Core.Entities.Service, Guid>
    {
        Task<IEnumerable<Core.Entities.Service>> GetServicesByHotelIdAsync(Guid id);

        Task<Core.Entities.Service> GetServiceByServiceIdAsync(Guid serviceId);
    }
}
