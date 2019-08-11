﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interface;
using BusinessManager.Service;
using CommanLayer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RepositoryManager.DBContext;
using RepositoryManager.Interface;
using RepositoryManager.Service;

namespace NotesMicroservice
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient<INotesRepositoryManager, NotesRepositoryManager>();
            services.AddTransient<IBusinessManager, BusinessManagerService>();

            services.AddTransient<ILabelRepositoryManager, LabelRepositoryService>();
            services.AddTransient<ILabelBusinessManager, LabelBusinessService>();

            //Get Connection to database
            services.AddDbContext<AuthenticationContext>(options =>
               options.UseSqlServer(this.Configuration.GetConnectionString("IdentityConnection")));

            //services.AddDefaultIdentity<NotesModel>()
            //    .AddEntityFrameworkStores<AuthenticationContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyFandooApp", Version = "v1" ,Description = "Fandoo App" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFandooApp");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
