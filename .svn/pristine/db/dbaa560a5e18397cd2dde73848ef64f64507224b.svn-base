using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.RequestDto
{
    public class StoreRequestDto
    {
        /// <summary>
        /// 0 ：入库 1：盘点 2： 下架（还在售）3：禁卖  4：售卖  
        /// </summary>
        public int StoreType { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 商铺Id
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 出入库实际数量
        /// 盘点：余量
        /// </summary>
        public int ModifyCount { get; set; }
    }
}
