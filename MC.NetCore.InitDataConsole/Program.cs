﻿using MC.NetCore.DataAccessSqlServerProvider;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using MC.NetCore.DomainModels;
using Microsoft.Extensions.Configuration;
using System.IO;
using MC.NetCore.Repository.Enums;
using MC.NetCore.Repository;
using System.Diagnostics;

namespace MC.NetCore.InitDataConsole
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
            //optionsBuilder.UseSqlServer(@"Data Source=123.57.21.63;Initial Catalog=OnlineFruit_Upgrade_V2;User ID=sa;Password=Happy2016;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));

            

            using (var db = new ShopDbContext(optionsBuilder.Options))
            {
                //ShopRepository shop = new ShopRepository(db);
                //var sw = new Stopwatch();
                //sw.Start();
                //shop.GetShopList().GetAwaiter().GetResult();
                //sw.Stop();
                //Console.WriteLine("Use {0} Milliseconds", sw.ElapsedMilliseconds);
                //var shopList = (from s in db.Shop.AsNoTracking()
                //                where (s.CourseTypeIds == "2561" || s.CourseTypeIds == "2561,")
                //                && s.IsEnable == true
                //                && s.Astatus == 0
                //                select s).ToList();

                //var PickMan = (from u in db.ShopUserInfo.AsNoTracking()
                //               where u.RoleId == 2
                //               select u).FirstOrDefault();



                //foreach (var shop in shopList)
                //{
                //    var batId = Guid.NewGuid().ToString();
                //    GoodsPickingBatch bat = new GoodsPickingBatch
                //    {
                //        Id = batId,
                //        DeliveryStatus = (int)DeliveryStatusEnum.PickUped,
                //        PickManId = PickMan?.UserId,
                //        PickMan = PickMan?.UserName,
                //        PickTime = DateTime.Now.AddHours(2),
                //        ShopId = shop.ShopId,
                //        ShopName = shop.ShopName,
                //        PickupType = 1
                //    };

                //    List<GoodsPickingDetail> list = new List<GoodsPickingDetail>();
                //    var productList = (from p in db.ProductLibrary.AsNoTracking()
                //                       join s in db.Shop.AsNoTracking()
                //                       on p.SpId equals s.ShopId
                //                       where (s.CourseTypeIds == "2561" || s.CourseTypeIds == "2561,")
                //                       && s.IsEnable.Value == true
                //                       && s.Astatus == 0
                //                       && p.Astatus == 0
                //                       && p.IsAvailable == true
                //                       && s.ShopId== shop.ShopId
                //                       select p
                //            ).ToList();

                //    foreach (var x in productList)
                //    {
                //        GoodsPickingDetail detail = new GoodsPickingDetail
                //        {
                //            PickBatchId = batId,
                //            ProductId = x.ProductId,
                //            ProductName = x.ProductName,
                //            PickAmount = 0,
                //        };
                //        list.Add(detail);
                //    }

                //    db.GoodsPickingBatch.Add(bat);
                //    db.GoodsPickingDetail.AddRange(list);
                //    db.SaveChanges();

                //}








                //List<ProductExtense> pextList = new List<ProductExtense>();
                //foreach (var product in productList)
                //{
                //    ProductExtense pex = new ProductExtense
                //    {
                //        ProductId = product.ProductId,
                //        ShopId = product.SpId.Value,
                //        CurrentCount = 0,       //初始化库存全部为0
                //        TotalCount = 10         //初始化饱和量
                //    };

                //    pextList.Add(pex);
                //}
                //Console.WriteLine("商品数量："+ pextList.Count);
                //db.ProductExtense.AddRange(pextList);
                //db.SaveChanges();
                Console.WriteLine("同步完毕！");

            }




            Console.ReadKey();
        }
    }
}