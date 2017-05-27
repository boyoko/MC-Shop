using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.Dto
{


    public partial class ShopDto
    {
        [System.ComponentModel.DataAnnotations.Key]
        /// <summary>
        /// 店铺Id
        /// </summary>
        public int ShopId { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 销售额（店铺上次捡货时间点的全部销售额）
        /// </summary>
        public decimal? TotalAmount { get; set; }
        /// <summary>
        /// 上次捡货时间
        /// </summary>
        public DateTime? PickTime { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        /// <summary>
        /// 批次Id ,
        /// </summary>
        public string PickBatchId { get; set; }

        /// <summary>
        /// 捡货员Id,用于过滤
        /// </summary>
        public string PickManId { get; set; }
        /// <summary>
        /// 捡货员
        /// </summary>
        public string PickMan { get; set; }

        /// <summary>
        /// 拣货状态 0： 未拣货 1：拣货未配送 
        /// </summary>
        public int PickStatus { get; set; }
    }
}
