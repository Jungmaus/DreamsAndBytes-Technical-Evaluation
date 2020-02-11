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
using AutoMapper;
using DreamsAndBytes.Extensions.Middleware;
using DreamsAndBytes.BLL.Order.Abstract;
using DreamsAndBytes.BLL.Order.Concrate;
using DreamsAndBytes.BLL.Payment.Abstract;
using DreamsAndBytes.BLL.Payment.Concrate;
using DreamsAndBytes.Enums;

namespace DreamsAndBytes.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public delegate IPayment PaymentServiceResolver(PaymentTypeEnum key);

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MssqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepository<BasketEntity>, Repository<BasketEntity>>();
            services.AddScoped<IRepository<OrderDetailEntity>, Repository<OrderDetailEntity>>();
            services.AddScoped<IRepository<OrderEntity>, Repository<OrderEntity>>();
            services.AddScoped<IRepository<ProductEntity>, Repository<ProductEntity>>();
            services.AddScoped<IRepository<ProductTypeEntity>, Repository<ProductTypeEntity>>();
            services.AddScoped<IRepository<UserDetailEntity>, Repository<UserDetailEntity>>();
            services.AddScoped<IRepository<UserEntity>, Repository<UserEntity>>();
                     
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IUserDetailService, UserDetailService>();
            services.AddScoped<IUserService, UserService>();
                     
            services.AddScoped<IHash, SHA512Hash>();
            services.AddScoped<ICrypto, AESCrypto>();

            services.AddScoped<IPayment, CreditCardPayment>();
            services.AddScoped<IPayment, KissPayment>();

            services.AddTransient<PaymentServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case PaymentTypeEnum.CreditCard:
                        return serviceProvider.GetService<CreditCardPayment>();
                    case PaymentTypeEnum.Kiss:
                        return serviceProvider.GetService<KissPayment>();
                    default:
                        throw new KeyNotFoundException(); 
                }
            });


            services.AddScoped<IOrder, Order>();

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Login/Index/";
            });

            services.AddAutoMapper(typeof(Startup));
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

            app.UseCultureMiddleware();
            app.UseLoginControlMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Product}/{action=Index}");
            });
        }
    }
}