using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Users
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
