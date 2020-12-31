using GenericStoredProcedure.API.Library.ConnectionFactory;
using GenericStoredProcedure.API.Library.ConnectionFactory.Interfaces;
using GenericStoredProcedure.API.Library.Data;
using GenericStoredProcedure.API.Library.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace GenericStoredProcedure.API
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

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            #region Interface and Class Mapping for DI

            services.AddTransient(typeof(IBaseStoredProcedure<>), typeof(BaseStoredProcedure<>));

            //For Connection DB (MySQL,SQLServer...)
            services.AddTransient<IConnectionFactory, ConnectionFactory>();

            #endregion        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
