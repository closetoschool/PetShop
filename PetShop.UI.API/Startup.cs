using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Services;
using PetShop.Core.DomainServices;
using PetShop.InfraStructure.Data;
using PetShop.InfraStructure.SQLite.Data;

namespace PetShop.UI.API
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
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", 
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "PetShop API Documentation",
                        Description = "Get to know the API",
                        Version = "v1"
                    });
            });
            
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();
            
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<ITypeRepository, TypeRepository>();

            // Ignore JSON model relations loop
            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //o.SerializerSettings.MaxDepth = 5;
            });

            services.AddDbContext<PetShopLiteContext>(opt =>
            {
                opt.UseSqlite("Data Source=petShop.db");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopLiteContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    var petRepository = scope.ServiceProvider.GetService<IPetRepository>();
                    var ownerRepository = scope.ServiceProvider.GetService<IOwnerRepository>();
                    var typeRepository = scope.ServiceProvider.GetService<ITypeRepository>();
                    //new DBInitializer(petRepository, ownerRepository, typeRepository).InitData();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PetShop API");
            });
        }
    }
}