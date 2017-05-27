﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels.RequestDto
{
    public partial class PickUpProductsRequestDto
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        /// <summary>
        /// 拣货开始时间，拣货可能需要很长时间，那么提交的时候不能是拣货完成后的当前时间，而是拣货开始的时间
        /// </summary>
        public DateTime PickStartTime { get; set; }
        public IList<ProductViewModel> ProductList { get; set; }

        public int Type { get; set; }
        public PickUpProductsRequestDto()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
        }
    }

    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public int AllSaleAmount { get; set; }
    }
}
