using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VegaApp.API.Data;

namespace VegaApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => 
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));                

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register VegaRepository and make it available for dependency injection
            // throughout the app.  
            // AddSingleton -- which means we will create a single instance of our Repository 
            // throughout the application but this will create some issues with concurrent 
            // http request
            // AddTransient -- useful for lightweight stateless services because these are
            // created each time they are requested
            // AddScoped -- which means the service is created per request within the scope
            // of the same http request.  Equivalent to AddSingleton but in the current scope
            // itself.  It creates one instance for each different http request but uses the same
            // instance in other codes within the same work request.  Suitable for the Repository
            // that we are creating.
            // In order to use AddScoped, we will specify the interface and the 
            // concrete implementation of the interface
            services.AddScoped<IVegaRepository, VegaRepository>();

            // Add the Seed class
            services.AddTransient<Seed>();

            // Add the AutoMapper services
            services.AddAutoMapper();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            Seed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Seed the user
            seeder.SeedData();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
