﻿using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Servicios;
using PeliculasAPI.Servicios.AzureStorage;
using PeliculasAPI.Servicios.LocalStorage;

namespace PeliculasAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //AZURE
            services.AddTransient<IAlmacenArchivos, AlmacenadorArchivosAzure>();

            //LOCAL
            //services.AddTransient<IAlmacenArchivos, AlmacenadorArchivosLocal>(); 
            services.AddHttpContextAccessor();
            
            //SQL Context
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            services.AddControllers()
                .AddNewtonsoftJson();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
             
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //para poder mistar las imágenes desde LocalHost
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
