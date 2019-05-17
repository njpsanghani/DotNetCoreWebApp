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
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;



namespace CoreWebApp
{
    public class Startup
    {

        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<TodoContext>(opt => 
            //     opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();
                //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                // c.SwaggerDoc("v1", new Info
                // {
                //     Version = "v1",
                //     Title = "ToDo API",
                //     Description = "A simple example ASP.NET Core Web API",
                //     TermsOfService = "None",
                //     Contact = new Contact
                //     {
                //         Name = "Shayne Boyer",
                //         Email = string.Empty,
                //         Url = "https://twitter.com/spboyer"
                //     },
                //     License = new License
                //     {
                //         Name = "Use under LICX",
                //         Url = "https://example.com/license"
                //     }
                // });

                // // Set the comments path for the Swagger JSON and UI.
                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // c.IncludeXmlComments(xmlPath);

                 c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        
            //services.AddSingleton<IHostedService, GracePeriodManagerService>();
        }
        #endregion

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // public void ConfigureServices(IServiceCollection services)
        // {
        //     services.AddMvc();
        // }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();

            app.UseSwagger();

             app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
