using MediatR;
using Microsoft.EntityFrameworkCore;
using Recobookation.App.Books;
using Recobookation.App.Core;
using Recobookation.Persistence;

namespace Recobookation.API.Commons.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options => options
                .UseSqlServer(config.GetConnectionString("DefaultConnection")));

            //cors policy allowing to safely retrive data returned by our api so the client-app can use the data
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

            //Mediator to simplify handling queries
            services.AddMediatR(typeof(BookList.Handler));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}