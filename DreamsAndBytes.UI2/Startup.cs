using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamsAndBytes.BLL.Payment;
using DreamsAndBytes.Core;
using DreamsAndBytes.DAL.Abstract;
using DreamsAndBytes.DAL.Concrate;
using DreamsAndBytes.Entity.Context;
using DreamsAndBytes.Entity.Entities.Basket;
using DreamsAndBytes.Entity.Entities.Order;
using DreamsAndBytes.Entity.Entities.Product;
using DreamsAndBytes.Entity.Entities.User;
using DreamsAndBytes.Security.Abstract;
using DreamsAndBytes.Security.Concrate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DreamsAndBytes.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MssqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IRepository<BasketEntity>, Repository<BasketEntity>>();
            services.AddTransient<IRepository<OrderDetailEntity>, Repository<OrderDetailEntity>>();
            services.AddTransient<IRepository<OrderEntity>, Repository<OrderEntity>>();
            services.AddTransient<IRepository<ProductEntity>, Repository<ProductEntity>>();
            services.AddTransient<IRepository<ProductTypeEntity>, Repository<ProductTypeEntity>>();
            services.AddTransient<IRepository<UserDetailEntity>, Repository<UserDetailEntity>>();
            services.AddTransient<IRepository<UserEntity>, Repository<UserEntity>>();

            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IUserDetailService, UserDetailService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IHash, SHA512Hash>();
            services.AddTransient<ICrypto, AESCrypto>();

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Login/Index/";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Login}/{action=Index}");
            });
        }
    }
}