using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.Dto
{
    public class DeliveryProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        /// <summary>
        /// 饱和量
        /// </summary>
        public int FullAmount { get; set; }
        /// <summary>
        /// 余量
        /// </summary>
        public int RemainderAmount { get; set; }
        /// <summary>
        /// 推荐上货量，默认等于饱和量
        /// </summary>
        public int RecommendOnShelvesAmount { get; set; }
    }
}
