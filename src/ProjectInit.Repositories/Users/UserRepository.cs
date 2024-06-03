using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Users
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(ProjectContext ctx) : base(ctx) {}
       
    }
}
