using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.RequestDto
{
    public class ShopStatisticQueryDto
    {
        public DateTime BeginDateTime { get; set; }
        public DateTime EnDateTime { get; set; }
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
    }
}
