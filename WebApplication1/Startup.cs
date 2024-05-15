﻿using CartService.Database.DbContext;
using Microsoft.EntityFrameworkCore;
using CartService.Database.Repositories;
using CartService.Database.Repositories.Interfaces;
using CartService.Services.Interfaces;

namespace CartService;

public class Startup
{
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureControllers(services);
        ConfigureSwagger(services);
        ConfigureScopedServices(services);
        ConfigureDatabaseContext(services);
    }

    private static void ConfigureControllers(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        services.AddEndpointsApiExplorer();
    }

    private void ConfigureDatabaseContext(IServiceCollection services)
    {
        services.AddDbContext<CartDbContext>(options =>
        {
            options.UseNpgsql(_configuration.GetConnectionString("CartDbContext"));
        });
    }

    private static void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });
    }
    private static void ConfigureScopedServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartService, Services.CartService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseWebSockets();
        app.UseCors(policyBuilder =>
        {
            policyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoint =>
        {
            endpoint.MapControllers();
            endpoint.MapRazorPages();
            //endpoint.MapHub<some sub>("some pattern");
        });
    }

}