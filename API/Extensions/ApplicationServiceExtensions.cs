using System;
using API.Data;
using API.Entities;
using API.Helpers;
using API.interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services,
    IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }
        );

        services.AddCors();
        services.AddScoped<ITokenService,TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPhotoService,PhotoService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

        return services;
    }
}
