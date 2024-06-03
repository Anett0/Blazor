using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Context;
using ProjectInit.Core.Entities;
using ProjectInit.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories.Pet
{
    public class PetRepository : Repository<Core.Entities.Pet, Guid>, IPetRepository
    {
        public PetRepository(ProjectContext ctx) : base(ctx) { }

        public async Task<IEnumerable<Core.Entities.Pet>> PetsByHotelUserIdAsync(Guid id)
        {
            var pets = await _ctx.Pets.Where(r => r.UserId == id).ToListAsync();

            return pets;
        }
    }
}
