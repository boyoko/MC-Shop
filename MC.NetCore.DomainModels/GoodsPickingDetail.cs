using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class GoodsPickingDetail
    {
        public string Id { get; set; }
        public string PickBatchId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int PickAmount { get; set; }
    }
}
