using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.MongoDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoTest2.Infrastructure;
using MongoTest2.Model;
using MongoTest2.Model.Entities;
using MongoTest2.Model.Repositories;


namespace MongoTest2
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

           
            services.AddCors(options => { options.AddPolicy("CorsPolicy", 
                                      builder => builder.AllowAnyOrigin() 
                                                        .AllowAnyMethod() 
                                                        .AllowAnyHeader() 
                                                        .AllowCredentials()); 
                                  }); 

            services.AddMvc();

            services.AddTransient<INoteRepository, NoteRepository>();

            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });


            services.AddIdentity<ApplicationUser,IdentityRole>()
                .RegisterMongoStores<ApplicationUser,IdentityRole>(Configuration.GetSection("MongoConnection:ConnectionString").Value+"/NotesDb");

            // services.Configure<IdentityOptions>(
            //     config => {
            //         config.Cookies..Events= 
            //             new CookieAuthenticationEvents(){
            //                 OnRedirectToLogin = (ctx) =>{
            //                     if(ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
            //                     {
            //                         ctx.Response.StatusCode = 401;
            //                     }
            //                     return Task.CompletedTask;
            //                 }
            //             };
            //     }
            // );


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            // global policy, if assigned here (it could be defined indvidually for each controller) 
            app.UseCors("CorsPolicy"); 

            app.UseIdentity();            

            app.UseMvc();

            app.UseStaticFiles();
        }
    }
}
