using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineTourAndTravelAgency.Models;
using OnlineTourAndTravelAgency.Tourdata;
using OnlineTourAndTravelAgency.TourData;

namespace OnlineTourAndTravelAgency
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
            services.AddCors(o => {
                o.AddPolicy("CorsPolicy", b => {
                    b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<TourAndTravelDbContext>(o => o.UseSqlServer(this.Configuration.GetConnectionString("con")));
            services.AddScoped(typeof(IRepository<>), typeof(TourDataRepository<>));
            services.AddScoped<INonGenericRepository, NonGenericRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}