using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.RequestDto
{
    public partial class OperationProductsRequestDto
    {
        public int ShopId { get; set; }
        //public string ShopName { get; set; }
        /// <summary>
        /// 操作类型：0：上货 1：盘点 2：下架某类商品一定数量（还在售）3：全部下架某类商品(禁止售卖)
        /// </summary>
        public int OperationType { get; set; }
        public IList<CheckStoreOrOnShelvesProductViewModel> ProductList { get; set; }
        public OperationProductsRequestDto()
        {
            List<CheckStoreOrOnShelvesProductViewModel> productList = new List<CheckStoreOrOnShelvesProductViewModel>();
        }
    }

    public class CheckStoreOrOnShelvesProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        /// <summary>
        /// 余量
        /// </summary>
        public int RemainCount { get; set; }
        /// <summary>
        /// 上货量 / 实际剩余量
        /// </summary>
        public int ProductCount { get; set; }
    }
}
