using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
        { //Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject----IoC Container
           // AOP
            services.AddControllers();
            //services.AddSingleton<ICarService, CarManager>();//Bana arka planda // içinde data tutulmamalý// data olunca Add Scoped
            //services.AddSingleton<ICarDal, EfCarDal>();
            //services.AddSingleton<IColorService, ColorManager>();//Bana arka planda // içinde data tutulmamalý// data olunca Add Scoped
            //services.AddSingleton<IColorDal, EfColorDal>();
            //services.AddSingleton<IBrandService, BrandManager>();//Bana arka planda // içinde data tutulmamalý// data olunca Add Scoped
            //services.AddSingleton<IBrandDal, EfBrandDal>();
            //services.AddSingleton<ICustomerService, CustomerManager>();//Bana arka planda // içinde data tutulmamalý// data olunca Add Scoped
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();
            //services.AddSingleton<IUserService, UserManager>();//Bana arka planda // içinde data tutulmamalý// data olunca Add Scoped
            //services.AddSingleton<IUserDal, EfUserDal>();
            //services.AddSingleton<IRentalService, RentalManager>();//Bana arka planda // içinde data tutulmamalý// data olunca Add Scoped
            //services.AddSingleton<IRentalDal, EfRentalDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
