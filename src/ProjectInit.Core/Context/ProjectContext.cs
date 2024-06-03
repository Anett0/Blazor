using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Entities;
using System.Data;
using System.Reflection.Emit;

namespace ProjectInit.Core.Context
{
    public class ProjectContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            builder.Seed();

          
            base.OnModelCreating(builder);
        }

        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Pet> Pets => Set<Pet>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Service> Services => Set<Service>();
        public override DbSet<User> Users => Set<User>();
    }
}
