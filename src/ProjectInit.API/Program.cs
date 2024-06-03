
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ProjectInit.API.Implementation;
using ProjectInit.API.Interfaces;
using ProjectInit.Core.Context;
using ProjectInit.Repositories.Common;

namespace ProjectInit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProjectContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectConnection")
                    , options => options.EnableRetryOnFailure());
            });
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            builder.Services.AddScoped<IFileService, FileService>();
            var app = builder.Build();
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "img");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(dir),
                RequestPath = "/images"
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
