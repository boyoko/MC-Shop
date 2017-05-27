using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class Shop
    {
        public int ShopId { get; set; }
        public int? BusinessId { get; set; }
        public string ShopName { get; set; }
        public string CourseTypeIds { get; set; }
        public string CourseTypeNames { get; set; }
        public decimal? Discount { get; set; }
        public double? Distance { get; set; }
        public decimal? AverageCost { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailPath { get; set; }
        public string Introduce { get; set; }
        public bool? IsDefault { get; set; }
        public string Telephone { get; set; }
        public string ShopLinkName { get; set; }
        public string ShopLinkTel { get; set; }
        public string AreaIds { get; set; }
        public string Groupid { get; set; }
        public decimal? Cx { get; set; }
        public decimal? Cy { get; set; }
        public int? Typeid { get; set; }
        public string LogoUrl { get; set; }
        public string ServiceDescription { get; set; }
        public int? ServiceLevel { get; set; }
        public string ServiceUrl { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string DeliverRemark { get; set; }
        public bool? IsAppUse { get; set; }
        public bool? IsWechatUse { get; set; }
        public string QrcodePath { get; set; }
        public int? ApplyUserId { get; set; }
        public bool? IsAudit { get; set; }
        public int? AuditStatus { get; set; }
        public int? AuditUserId { get; set; }
        public string Remark { get; set; }
        public DateTime? ApplyTime { get; set; }
        public DateTime? AuditTime { get; set; }
        public string PayQrCodePath { get; set; }
        public int? IsIslam { get; set; }
        public decimal? MinOrderMoney { get; set; }
        public bool? IsEnable { get; set; }
        public bool? IsEnterprise { get; set; }
        public decimal? ShopLeftMoney { get; set; }
        public string InvoiceTitles { get; set; }
        public bool IsSpecialFunds { get; set; }
        public string ShopInviCode { get; set; }
        public int? OpenChannel { get; set; }
        public int? AcertificateId { get; set; }
        public int? RegistState { get; set; }
        public string Employees { get; set; }
        public string Aprovince { get; set; }
        public string Acity { get; set; }
        public string Acounty { get; set; }
        public int? Aowner { get; set; }
        public int? AadminRole { get; set; }
        public int Astatus { get; set; }
        public int Asort { get; set; }
        public DateTime AcreateDate { get; set; }
        public DateTime AmodifyDate { get; set; }
        public decimal? AmemDiscount { get; set; }
        public string Afrom { get; set; }
        public bool? AisSetBillRule { get; set; }
        public int? AbillGenerateType { get; set; }
        public decimal? AapplyPayLimitMoney { get; set; }
        public int? AapplyPayLimitDays { get; set; }
        public bool? Adistrict { get; set; }
        public bool? Aarea { get; set; }
        public string AareaList { get; set; }
        public int? AgroupId { get; set; }
        public string AdistrictId { get; set; }
        public bool? AisShare { get; set; }
        public bool? AisForShop { get; set; }
        public string ForshopIds { get; set; }
        public string ExpressList { get; set; }

    }
}
