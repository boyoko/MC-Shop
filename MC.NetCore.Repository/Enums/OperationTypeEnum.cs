using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.Repository.Enums
{
    public enum OperationTypeEnum
    {
        /// <summary>
        /// 上货（含新品上架）
        /// </summary>
        OnShelves = 0,
        /// <summary>
        /// 盘点
        /// </summary>
        CheckStore = 1,

        /// <summary>
        /// 下架某类商品一定数量（还在售）
        /// </summary>
        OffShelves = 2,

        /// <summary>
        /// 全部下架某类商品(禁止售卖)
        /// </summary>
        SoldOut = 3,
        /// <summary>
        /// 正常售卖
        /// </summary>
        Sale = 4

    }
}
