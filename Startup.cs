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
using MongoTest2.Data;
using MongoTest2.Data.Entities;
using MongoTest2.Data.Repositories;
using MongoTest2.Data.Seeding;
using MongoTest2.Infrastructure.Crypto;

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
            services.AddTransient<NoteContext>();   //AddScoped
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICryptoStrategy, EmptyCryptoStrategy>();
            services.AddTransient<IdentitySeed>();
            services.AddTransient<Infrastructure.Crypto.ISignInManager, Infrastructure.Crypto.CryptoSignInManager>();
         //   services.AddTransient<Microsoft.AspNetCore.Identity.SignInManager<Credentials>>();
            	

            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });


            services.AddIdentity<ApplicationUser,IdentityRole>()             
                .RegisterMongoStores<ApplicationUser,IdentityRole>(Configuration.GetSection("MongoConnection:ConnectionString").Value+"/NotesDb")
                .AddUserStore<CustomUserStore>()
                .AddDefaultTokenProviders();


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
