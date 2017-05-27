using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class ShopUserInfo
    {
        public string UserId { get; set; }
        /// <summary>
        /// '1：管理员  2：拣货员 3：送货员'
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 管理员  拣货员  配送员
        /// </summary>
        public string RoleName { get; set; }
        public string UserName { get; set; }
	    public string Password { get; set; }
	    public string RealName { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
