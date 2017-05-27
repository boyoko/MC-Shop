using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MC.NetCore.DataAccessSqlServerProvider;
using Microsoft.EntityFrameworkCore;
using MC.NetCore.Repository;
using MC.NetCore.ShopApp.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace MC.NetCore.ShopApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddMvc();

            //自定义错误过滤
            services.AddMvc(opts =>
            {
                //Here it is being added globally. 
                //Could be used as attribute on selected controllers instead
                opts.Filters.Add(new CustomJSONExceptionFilter());
            }).AddJsonOptions(options => options.SerializerSettings.ContractResolver
            = new DefaultContractResolver());

            #region session
            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(365);
                options.CookieHttpOnly = true;
            });
            #endregion

            services.AddDbContext<ShopDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));

            services.AddScoped<IOperationRepository, OperationRepository>();

            //获取商铺列表信息
            services.AddScoped<IShopRepository, ShopRepository>();

            //获取商品列表信息
            services.AddScoped<IProductRepository, ProductRepository>();

            //捡货
            services.AddScoped<IPickUpRepository, PickUpRepository>();

            //用户信息
            services.AddScoped<IShopUserRepository, ShopUserRepository>();

            //库存接口
            services.AddScoped<IStoreRepository, StoreRepository>();

            // support cors
            #region 跨域
            //var urls = Configuration["AppConfig:Cores"].Split(',');
            //var urls = "http://localhost:5000/";
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
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            loggerFactory.AddNLog();//添加NLog

            env.ConfigureNLog("Nlog.config");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();

            


            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            // support cors
            app.UseCors("AllowAnyDomain");
        }
    }
}
