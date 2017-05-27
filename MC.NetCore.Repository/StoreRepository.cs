using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MC.NetCore.DomainModels.RequestDto;
using MC.NetCore.DataAccessSqlServerProvider;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MC.NetCore.Repository.Enums;
using MC.NetCore.DomainModels;
using Microsoft.Extensions.Logging;

namespace MC.NetCore.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ShopDbContext _shopDbContext;
        private ILogger<StoreRepository> _logger;

        public StoreRepository(ShopDbContext context, ILogger<StoreRepository> logger)
        {
            _shopDbContext = context;
            _logger = logger;
        }
        public async Task<bool> UpdateStore(IList<StoreRequestDto> request)
        {
            try
            {
                //无需检查库存数量，直接增，扣库存
                if (request != null && request.Any())
                {
                    List<ProductExtense> productExtList = new List<ProductExtense>();
                    foreach (var x in request)
                    {
                        var product = _shopDbContext.ProductExtense.FirstOrDefault(a => a.ProductId == x.ProductId);
                        if (product == null)
                            return false;
                        _logger.LogInformation("Current data in  ProductExtense Shopid :{0}, ProductId:{1} ModifyCount:{2} CurrentCount:{3} ", x.ShopId,x.ProductId,x.ModifyCount,product.CurrentCount);
                        //兼容参数中没有传shopId
                        if (product.ShopId <= 0)
                        {
                            product.ShopId = _shopDbContext.ProductLibrary.FirstOrDefault(a => a.ProductId == product.ProductId).SpId.Value;
                        }
                        switch (x.StoreType)
                        {
                            case (int)OperationTypeEnum.OnShelves:  //上货
                                product.CurrentCount = product.CurrentCount + x.ModifyCount;
                                //上货结束后改变批次表状态
                                break;
                            case (int)OperationTypeEnum.CheckStore:  //盘点
                                product.CurrentCount = x.ModifyCount;
                                break;
                            case (int)OperationTypeEnum.OffShelves:  //下架(在售)
                                product.CurrentCount = product.CurrentCount - x.ModifyCount;
                                break;
                            case (int)OperationTypeEnum.SoldOut: //下架
                                product.CurrentCount = product.CurrentCount - x.ModifyCount;
                                //修改商品表中商品状态
                                break;
                            case (int)OperationTypeEnum.Sale:  //售卖
                                product.CurrentCount = product.CurrentCount - x.ModifyCount;
                                break;
                            default:
                                break;

                        }
                        _logger.LogInformation("Changed Data to ShopId:{0} ProductId:{1} ModifyCount:{2} CurrentCount:{3} ", x.ShopId, x.ProductId, x.ModifyCount, product.CurrentCount);
                        productExtList.Add(product);
                    }
                    try
                    {

                        _shopDbContext.UpdateRange(productExtList);
                        _shopDbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogInformation(ex.Message);
                    }
                   
                    if (request.First().StoreType == (int)OperationTypeEnum.OnShelves)
                    {
                        await UpdateDeliveryStatus(request.First().ShopId);
                    }
                    if (request.First().StoreType == (int)OperationTypeEnum.SoldOut)
                    {
                        await UpdateProductStatus(request.First().ProductId);
                    }
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private async Task<bool> UpdateDeliveryStatus(int shopId)
        {
            try
            {
                var googbatch = _shopDbContext.GoodsPickingBatch.Where(c => c.ShopId == shopId).ToList();

                foreach(var x in googbatch)
                {
                    x.DeliveryStatus = (int)DeliveryStatusEnum.Deliveryed;
                    _shopDbContext.Entry(x).State = EntityState.Modified;
                }
                //googbatch.DeliveryStatus = (int)DeliveryStatusEnum.Deliveryed;
                // _shopDbContext.Entry(googbatch).State = EntityState.Modified;
                await _shopDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private async Task<bool> UpdateProductStatus(int productId)
        {
            try
            {
                var product = _shopDbContext.ProductLibrary.FirstOrDefault(c => c.ProductId == productId);
                //product.Astatus = 1;  //删除状态
                product.IsAvailable = false;  //下架状态
                _shopDbContext.Entry(product).State = EntityState.Modified;
                await _shopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
