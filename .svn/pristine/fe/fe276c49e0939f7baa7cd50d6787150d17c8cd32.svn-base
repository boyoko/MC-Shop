using MC.NetCore.DomainModels;
using MC.NetCore.DomainModels.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MC.NetCore.Repository
{
    public interface IShopRepository
    {
        Task<IList<ShopDto>> GetShopList();

        Task<IList<DeliveryShopDto>> GetDeliverShopList();

        Task<IList<ShopDto>> GetShopList(int? shopId, string shopName);

    }
}
