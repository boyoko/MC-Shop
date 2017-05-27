﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.Dto
{
    public class DeliveryShopDto
    {
        /// <summary>
        /// 配送状态 0、未捡货 1、已捡货未发货 2、已配送（完成上货动作）
        /// </summary>
        public int DeliveryStatus { get; set; }

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
        /// 余量 百分比（所有商品的库存量 * 单价  /  所有商品的饱和量 * 单价） 
        /// </summary>
        public decimal? Surplus { get; set; }
        /// <summary>
        /// 距离
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Distance { get; set; }

        /// <summary>
        /// 上次配送时间
        /// </summary>
        public DateTime? DeliveryTime { get; set; }

        /// <summary>
        /// 配送员Id,用于过滤
        /// </summary>
        public string DeliveryManId { get; set; }
        /// <summary>
        /// 配送员
        /// </summary>
        public string DeliveryMan { get; set; }
    }
}
