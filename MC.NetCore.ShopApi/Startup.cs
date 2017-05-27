using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MC.NetCore.Repository;
using MC.NetCore.DataAccessSqlServerProvider;
using Microsoft.EntityFrameworkCore;

namespace MC.NetCore.ShopApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<ShopDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));

            services.AddScoped<IOperationRepository, OperationRepository>();

            //获取商铺列表信息
            services.AddScoped<IShopRepository, ShopRepository>();

            //获取商品列表信息
            services.AddScoped<IProductRepository, ProductRepository>();

            //捡货
            services.AddScoped<IPickUpRepository, PickUpRepository>();


            // support cors
            #region 跨域
            //var urls = Configuration["AppConfig:Cores"].Split(',');
            //var urls = new List<string>
            //{
            //    "http://192.168.1.113:4200/",
            //    "http://192.168.1.113:5000/",
            //    "http://192.168.1.109:4200",
            //    "http://10.9.35.60:5000"
            //};
            services.AddCors(options =>
            options.AddPolicy("AllowAnyDomain", builder => builder.WithOrigins()
                                                                     .AllowAnyMethod()
                                                                     .AllowAnyHeader()
                                                                     .AllowAnyOrigin()
                                                                     .AllowCredentials())
            );
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
