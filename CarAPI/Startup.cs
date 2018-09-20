﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using CarAPI.Model;
using Swashbuckle.AspNetCore.Swagger;

namespace CarAPI
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
             //services.AddDbContext<CarDBContext>(opt => opt.UseInMemoryDatabase("CarsDatabase"));

            services.AddDbContext<CarDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CarsDatabase")));
            services.AddMvc();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title="Cars API", Version="v1" }));
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Cars API v1"));
            app.UseMvc();
        }
    }
}
