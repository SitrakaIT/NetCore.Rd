using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NetCore.Rd.Data.Context;
using AutoMapper;
using NetCore.Rd.Business.Apartments;
using NetCore.Rd.Repository.Apartments;
using NetCore.Rd.Business.Owners;
using NetCore.Rd.Repository.Owners;

namespace NetCore.Rd.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public IConfiguration _Configuration { get; }

        public static readonly LoggerFactory _MyLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information, true)
            });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(
                options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }
            );
            //services.AddMvc().AddXmlSerializerFormatters();
            services.AddDbContext<ApplicationContext>(options => {
                options
                .UseSqlServer(_Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NetCore.Rd.Web"))
                .UseLoggerFactory(_MyLoggerFactory);
            }, ServiceLifetime.Singleton);

            services.AddSingleton<IApartmentBusiness, ApartmentBusiness>();
            services.AddSingleton<IApartmentRepository, ApartmentRepository>();

            services.AddSingleton<IOwnerBusiness, OwnerBusiness>();
            services.AddSingleton<IOwnerRepository, OwnerRepository>();
            // Data Mapper
            services.AddAutoMapper();
            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });

            // Data Protection
            services.AddDataProtection();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseCors("AllowSpecificOrigin");
        }
    }
}
