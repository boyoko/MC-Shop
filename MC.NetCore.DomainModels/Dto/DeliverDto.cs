using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.Dto
{
    public class DeliverDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<int> ShopId { get; set; }
    }
}
