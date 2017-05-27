using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.Dto
{
    public partial class UserDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int? ShopId { get; set; }
    }
}
