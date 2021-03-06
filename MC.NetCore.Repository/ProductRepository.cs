﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MC.NetCore.DomainModels.Dto;
using MC.NetCore.DataAccessSqlServerProvider;
using MC.NetCore.DomainModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MC.NetCore.Common.Extensions;
using MC.NetCore.Repository.Enums;

namespace MC.NetCore.Repository
{
    public class ProductRepository :Repository<ProductLibrary>, IProductRepository,IDisposable
    {
        private readonly ShopDbContext _shopDbContext;
        public ProductRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<IList<ProductLibrary>> GetProductListByShopId(HashSet<int> shopIds)
        {        
            return await (from p in _shopDbContext.ProductLibrary.AsNoTracking()
                          where shopIds.Contains(p.SpId.HasValue ? p.SpId.Value : 0)
                          select p).ToListAsync();
        }

        public async Task<ProductLibrary> GetProductListByProductId(int productId)
        {
            return await (from p in _shopDbContext.ProductLibrary.AsNoTracking()
                          where productId == p.ProductId
                          select p).FirstOrDefaultAsync();
        }

        public async Task<IList<DeliveryProductDto>> GetDeliveryProductList(int shopId)
        {
            var productList =await (from p in _shopDbContext.ProductLibrary.AsNoTracking()
                               join px in _shopDbContext.ProductExtense.AsNoTracking()
                               on p.ProductId equals px.ProductId
                               where px.ShopId == shopId
                               && px.ShopId == p.SpId
                               && p.Astatus == 0
                               && p.IsAvailable == true
                               select new DeliveryProductDto
                               {
                                   ProductId = p.ProductId,
                                   ProductName = p.ProductName,
                                   FullAmount =  px.TotalCount.Value,
                                   RemainderAmount = px.CurrentCount.Value,
                                   RecommendOnShelvesAmount = 0
                               }).DistinctByAsync(a=>a.ProductId);

            productList.ForEach(a=>a.RecommendOnShelvesAmount= SetRecommendOnShelvesAmount(a.ProductId));


            return productList;
        }

        public async Task<IList<DeliveryProductDto>> GetDeliveryProductList2(int shopId)
        {
            var productList = await (from p in _shopDbContext.ProductLibrary.AsNoTracking()
                                     join px in _shopDbContext.ProductExtense.AsNoTracking()
                                     on p.ProductId equals px.ProductId into left_px 
                                     from ce in left_px.DefaultIfEmpty()
                                     where p.SpId == shopId
                                     && p.Astatus == 0
                                     && p.IsAvailable == true
                                     select new DeliveryProductDto
                                     {
                                         ProductId = p.ProductId,
                                         ProductName = p.ProductName,
                                         FullAmount = ce==null?0:ce.TotalCount.Value,
                                         RemainderAmount = ce == null ? 0 : ce.CurrentCount.Value,
                                         RecommendOnShelvesAmount = 0
                                     }).DistinctByAsync(a => a.ProductId);
            productList.ForEach(a => a.RecommendOnShelvesAmount = SetRecommendOnShelvesAmount(a.ProductId));


            return productList;
        }


        private int SetRecommendOnShelvesAmount(int productId)
        {
            var tmp = (from bat in _shopDbContext.GoodsPickingBatch.AsNoTracking()
                       join d in _shopDbContext.GoodsPickingDetail.AsNoTracking()
                       on bat.Id equals d.PickBatchId
                       where bat.DeliveryStatus==(int)DeliveryStatusEnum.PickUped
                       && d.ProductId== productId
                       select d.PickAmount).Sum();
            return tmp;
        }


        public async Task<IList<ProductDto>> GetProductList(int shopId, DateTime? lastPickTime, DateTime? pickTime)
        {
            var query = await (from product in _shopDbContext.ProductLibrary
                               join singleGoodsPickingBatch in _shopDbContext.GoodsPickingBatch
                               on new { ID = product.SpId.HasValue ? product.SpId.Value : 0, DeliveryStatus = 1 } equals
                                  new { ID = singleGoodsPickingBatch.ShopId, DeliveryStatus = singleGoodsPickingBatch.DeliveryStatus }
                                  into goodsPickingBatches
                               from singleBatch in goodsPickingBatches.DefaultIfEmpty()
                               join detail in _shopDbContext.GoodsPickingDetail on singleBatch.Id equals detail.PickBatchId into batchDetail
                               from singleDetail in batchDetail.DefaultIfEmpty()
                               join productEx in _shopDbContext.ProductExtense on product.ProductId equals productEx.ProductId into productExtensions
                               from productExtension in productExtensions.DefaultIfEmpty()
                               where product.SpId == shopId && product.Astatus == 0 && product.IsAvailable == true
                               select new ProductDto
                               {
                                   ProductId = product.ProductId,
                                   ProductName = product.ProductName,
                                   AllSaleAmount = productExtension == null ? 0 : productExtension.TotalCount.HasValue ? productExtension.CurrentCount.HasValue ? productExtension.TotalCount.Value - productExtension.CurrentCount.Value : productExtension.TotalCount.Value : 0,
                                   PickAmount = singleDetail == null ? 0 : singleDetail.PickAmount
                               }
                              ).ToListAsync();
            var result = query.GroupBy(m => new { ProductId = m.ProductId, ProductName = m.ProductName, }).Select(m =>
                   new ProductDto()
                   {
                       ProductId = m.Key.ProductId,
                       ProductName = m.Key.ProductName,
                       AllSaleAmount = m.First().AllSaleAmount - m.Aggregate(0, (i, dto) => i + dto.PickAmount, n => n),
                       PickAmount = m.First().AllSaleAmount - m.Aggregate(0, (i, dto) => i + dto.PickAmount, n => n)
                   }).ToList();
            result.Where(m => m.PickAmount < 0).All(m=> { m.PickAmount = 0; return true; });
            return result;
        }
    }
}
