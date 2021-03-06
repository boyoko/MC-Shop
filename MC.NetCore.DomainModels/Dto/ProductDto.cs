﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.Dto
{
    public partial class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        /// <summary>
        /// 实际销量/推荐拣货量
        /// </summary>
        public int AllSaleAmount { get; set; }
        /// <summary>
        /// 实际捡货量
        /// </summary>
        public int PickAmount { get; set; }
        
    }
}
