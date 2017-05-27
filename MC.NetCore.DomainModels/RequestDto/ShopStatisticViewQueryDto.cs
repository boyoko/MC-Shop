using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.RequestDto
{
    public class ShopStatisticViewQueryDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string ShopNameKey { set; get; }
        public int? ShopID { set; get; }
        public string OrderKey { get; set; }

        public bool OrderOrention { get; set; }

        private int pageIndex = 1;
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize = 12;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public ShopStatisticQueryDto ToShopStatisticQueryDto()
        {
            return new ShopStatisticQueryDto()
            {
                ShopID = this.ShopID,
                ShopNameKey = this.ShopNameKey,
                OrderKey = this.OrderKey,
                OrderOrention = this.OrderOrention,
                PageSize = this.PageSize,
                PageIndex = this.PageIndex,
                BeginDateTime = new DateTime(this.Year, this.Month, 1),
                EnDateTime = new DateTime(this.Year, this.Month + 1, 1).AddSeconds(-1)
            };
        }
    }
}
