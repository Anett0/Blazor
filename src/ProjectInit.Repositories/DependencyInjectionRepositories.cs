using Microsoft.Extensions.DependencyInjection;
using ProjectInit.Core.Context;
using ProjectInit.Repositories.Booking;
using ProjectInit.Repositories.Common;
using ProjectInit.Repositories.Hotel;
using ProjectInit.Repositories.Pet;
using ProjectInit.Repositories.Review;
using ProjectInit.Repositories.Service;
using ProjectInit.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Repositories
{
    public static class DependencyInjectionRepositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
    }
}
