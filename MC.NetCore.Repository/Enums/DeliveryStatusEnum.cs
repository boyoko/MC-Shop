using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.Repository.Enums
{
    public enum DeliveryStatusEnum
    {
        /// <summary>
        /// 未拣货
        /// </summary>
        UnPickUp = 0,
        /// <summary>
        /// 已拣货
        /// </summary>
        PickUped = 1,
        /// <summary>
        /// 已配送
        /// </summary>
        Deliveryed = 2
    }
}
