﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class GoodsPickingBatch
    {
        public string Id { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string PickManId { get; set; }
        public string PickMan { get; set; }
        public DateTime PickTime { get; set; }
        public int DeliveryStatus { get; set; }
        public int? PickupType { get; set; }
    }
}
