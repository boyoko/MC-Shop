using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class ProductExtense
    {
        public string ProductExtId { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
        public int? CurrentCount { get; set; }
        public int? TotalCount { get; set; }
    }
}
