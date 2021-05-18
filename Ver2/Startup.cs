using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ver2.Data;
using Ver2.Data.Interfaces;
using Ver2.Data.Mocks;
using Ver2.Data.Models;
using Ver2.Data.Repository;

namespace Ver2
{
    public class Startup
    {
        private IConfigurationRoot _confString;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            //отримання файлу зі строкою підключення БД
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.
           ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //зв'язування інтерфейсу з його реалізацією
            services.AddTransient<IAllRooms, RoomRepository>();
            services.AddTransient<IRoomsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddMvc(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(
                    _confString.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            //відображення помилок
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();//відображення коду сторінки 8
            app.UseStaticFiles();//для відображення різних файлів, таких
                                 //як зображення, css-файли та інше
            app.UseMvcWithDefaultRoute();//для маршрутизації за замовчування
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.
                GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
            app.UseMvcWithDefaultRoute();//для маршрутизації за замовчування
            app.UseSession();
            //прописуємо власну маршрутизацію та url-адреси
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controllerHome}/{action-Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template:
               "Rooms/{action}/{category?}", defaults: new
               {
                   Controller = "Rooms",
                   action = "List"
               });
            });
        }
    }
}
