using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class BoutiqueOperationLog
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
        public int? ChangeCount { get; set; }
        public string DeliveryManId { get; set; }
        public string DeliveryMan { get; set; }
        public int OperationType { get; set; }
        public int? LostCount { get; set; }
        public DateTime OperationDateTime { get; set; }
    }
}
