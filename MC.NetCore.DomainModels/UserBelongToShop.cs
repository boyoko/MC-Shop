using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class UserBelongToShop
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int? ShopId { get; set; }
    }
}
