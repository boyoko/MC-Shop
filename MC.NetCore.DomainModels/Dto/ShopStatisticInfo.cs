﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC.NetCore.DomainModels.Dto
{
    public class ShopStatisticInfo : ShopStatisticInfoDetail
    {
        public ShopStatisticInfo()
        {
        }

        public ShopStatisticInfo(int shopId, string shopName)
        {
            ShopID = shopId;
            ShopName = shopName;
            details = new List<ShopStatisticInfoDetail>();
        }

        public int ShopID { set; get; }
        public string ShopName { set; get; }

        private List<ShopStatisticInfoDetail> details;
        public IEnumerable<ShopStatisticInfoDetail> Details
        {
            get { return details.Where(m => m.EndDate.HasValue); }
        }

        public ShopStatisticInfoDetail CreatDetail(DateTime beginDateTime)
        {
            var retval = new ShopStatisticInfoDetail();
            retval.BeginDate = beginDateTime;
            retval.CheckOut += UpdateCreditScore;
            if (details == null)
                details = new List<ShopStatisticInfoDetail>();
            details.Add(retval);
            return retval;
        }

        private void UpdateCreditScore()
        {
            this.BeginDate = this.Details.First().BeginDate;
            this.EndDate = this.Details.Last().EndDate;
            this.SellMoney = this.Details.Sum(m => m.SellMoney);
            this.LostMoney = this.Details.Sum(m => m.LostMoney);
        }
    }
    public class ShopStatisticInfoDetail
    {
        public event Action CheckOut;
        private void OnCheckOut()
        {
            if (CheckOut != null)
                CheckOut();
        }
        public DateTime? BeginDate { get; set; }
        private DateTime? endDate;
        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnCheckOut();
            }
        }
        public decimal SellMoney { set; get; }
        public decimal LostMoney { get; set; }
        public decimal CreditScore
        {
            get
            {
                return SellMoney == 0 ? LostMoney > 0 ? 0 : 100 : Math.Round((SellMoney - LostMoney) * 100 / SellMoney, 2);
            }
        }
    }
}
