using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class OrderForm
    {
        public long OrderId { get; set; }
        public int ShopId { get; set; }
        public string OpenId { get; set; }
        public string OrderCode { get; set; }
        public string MemberId { get; set; }
        public int? MemberAddressId { get; set; }
        public int? OrderYear { get; set; }
        public int? OrderMonth { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime? OrderAcceptTime { get; set; }
        public DateTime? OrderActualDiliveryTime { get; set; }
        public DateTime? OrderFinishTime { get; set; }
        public string OrderContent { get; set; }
        public string DiliveryTimeDescription { get; set; }
        public string DiliveryRemark { get; set; }
        public int? DiliveryPersonId { get; set; }
        public string DiliveryAddress { get; set; }
        public int? Status { get; set; }
        public decimal? OrderMoney { get; set; }
        public decimal? OrderOutMoney { get; set; }
        public decimal? OrderActualMoney { get; set; }
        public string CustomerComments { get; set; }
        public int? FeedBackLevel { get; set; }
        public decimal? DiliveryCost { get; set; }
        public bool? IsComment { get; set; }
        public string PaymentType { get; set; }
        public int? PayStatus { get; set; }
        public DateTime? PayTime { get; set; }
        public string IssueDescription { get; set; }
        public decimal? Cashpay { get; set; }
        public decimal? Cashreceive { get; set; }
        public bool? IsReply { get; set; }
        public string ReplyContent { get; set; }
        public DateTime? ReplyTime { get; set; }
        public int? Apptype { get; set; }
        public int? QualityScore { get; set; }
        public int? ServiceScore { get; set; }
        public string Comments { get; set; }
        public int? BalanceStatus { get; set; }
        public decimal? WxhandlingCharge { get; set; }
        public decimal? MrichHandlingCharge { get; set; }
        public decimal? MrichServiceCharge { get; set; }
        public decimal? SaveMoney { get; set; }
        public bool? NeedInvoice { get; set; }
        public string InvoiceName { get; set; }
        public bool? NeedBalance { get; set; }
        public decimal? Discount { get; set; }
        public string OrderReceiverName { get; set; }
        public string OrderReceiverMobile { get; set; }
        public short? ParentPaymentTypeId { get; set; }
        public short? PaymentTypeId { get; set; }
        public short? ConsumeType { get; set; }
        public decimal? RefundMoney { get; set; }
        public string ExpressNum { get; set; }
        public string ExpressCompany { get; set; }
        public string ExpressCode { get; set; }
        public short? AdiliveryType { get; set; }
        public short? Awltype { get; set; }
        public decimal? AinvoiceMoney { get; set; }
        public decimal? AcardDymoney { get; set; }
        public bool? AneedBalanceTwo { get; set; }
        public short? AbalanceStatusTwo { get; set; }
        public decimal? AorderActualMoney { get; set; }
        public int? ShopIdex { get; set; }
        public int? AorderType { get; set; }
        public bool? AisQianDao { get; set; }
        public DateTime? AqianDaoTime { get; set; }
        public string AprojectName { get; set; }
        public string AorderGroupId { get; set; }
        public DateTime? AgroundStartTime { get; set; }
        public int? AsportsType { get; set; }
    }
}
