﻿using System;
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

            // CORS - Cross-Origin Resource Sharing.  It is a security measure which allows which
            // client to access our API.
            // Our Angular app domain is http://localhost:4200/ and our API domain is http://localhost:5000/
            // Initially, when running the Angular app, we will have a console error:
            // No 'Access-Control-Allow-Origin' header is present on the requested resource.
            // We will add a little bit loose cross-origin resource sharing policy to our API
            services.AddCors();

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
            
            //app.UseHttpsRedirection();

            // We need to call this before we will be calling UseMvc()
            // This is very loose policy and is suitable only when developing
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();
        }
    }
}
