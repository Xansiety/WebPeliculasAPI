using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using PeliculasAPI.Helpers;
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

            //Para indicar el sistema de coordenada para representare coordenadas en el mapa
            services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));

            services.AddSingleton(provider =>
                new MapperConfiguration(config =>
                {
                    var geometryFactory= provider.GetRequiredService<GeometryFactory>();
                    config.AddProfile(new AutoMapperProfiles(geometryFactory));
                }).CreateMapper()
            );
            //SQL Context
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            sqlServerOptions => sqlServerOptions.UseNetTopologySuite() //para poder usar se instala Microsoft.EntityFrameworkCore.SqlServer.TopologySuite
            ));

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
