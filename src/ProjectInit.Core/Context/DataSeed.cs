using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Entities;
using ProjectInit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Context
{
    public static class DataSeed
    {

        public static void Seed(this ModelBuilder builder)
        {
            var (arID, trID) = _seedRoles(builder);

            var teacherId = _seedUsers(builder, trID, arID);

            

        }
        private static (Guid, Guid) _seedRoles(ModelBuilder builder)
        {
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var USER_ROLE_ID = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>()
               .HasData(
                   new IdentityRole<Guid>
                   {
                       Id = ADMIN_ROLE_ID,
                       Name = "Admin",
                       NormalizedName = "ADMIN",
                       ConcurrencyStamp = ADMIN_ROLE_ID.ToString()
                   },
                   new IdentityRole<Guid>
                   {
                       Id = USER_ROLE_ID,
                       Name = "Teacher",
                       NormalizedName = "TEACHER",
                       ConcurrencyStamp = USER_ROLE_ID.ToString()
                   }
                 
               );


            return (ADMIN_ROLE_ID, USER_ROLE_ID);

        }

        private static Guid _seedUsers(ModelBuilder builder, Guid USER_ROLE_ID, Guid ADMIN_ROLE_ID)
        {
            var userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                UserName = "admin@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Анна Стерник"
            };

            var user2 = new User
            {
                Id = Guid.NewGuid(),
                UserName = "user@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "user@gmail.com".ToUpper(),
                Email = "user@gmail.com",
                NormalizedEmail = "user@gmail.com".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Максим Поліщук"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Qwerty-1");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Qwerty-1");

            builder.Entity<User>()
                .HasData(user, user2);

            builder.Entity<IdentityUserRole<Guid>>()
              .HasData(
                  new IdentityUserRole<Guid>
                  {
                      RoleId = ADMIN_ROLE_ID,
                      UserId = userId
                  },
                  new IdentityUserRole<Guid>
                  {
                      RoleId = USER_ROLE_ID,
                      UserId = userId
                  }
              );

            return userId;
        }

       
    }
}
