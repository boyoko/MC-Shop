using MC.NetCore.DataAccessSqlServerProvider;
using System;
using System.Collections.Generic;
using System.Text;
using MC.NetCore.DomainModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace MC.NetCore.Repository
{
    public class PickUpRepository:IPickUpRepository
    {
        private readonly ShopDbContext _shopDbContext;
        public PickUpRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<bool> PickUp(GoodsPickingBatch main, IList<GoodsPickingDetail> detailList)
        {
            IDbContextTransaction transaction = null;
            try
            {
                transaction =  _shopDbContext.Database.BeginTransaction();
                _shopDbContext.GoodsPickingBatch.Add(main);
                _shopDbContext.GoodsPickingDetail.AddRange(detailList);
                await _shopDbContext.SaveChangesAsync();
                transaction.Commit();
                transaction.Dispose();
                return true;
            }
            catch(Exception e)
            {
                transaction.Rollback();
                throw e;
            }
            
        }
    }
}
