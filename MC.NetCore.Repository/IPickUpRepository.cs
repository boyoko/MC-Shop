using MC.NetCore.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MC.NetCore.Repository
{
    public interface IPickUpRepository
    {
        Task<bool> PickUp(GoodsPickingBatch main,IList<GoodsPickingDetail> detailList);
    }
}
