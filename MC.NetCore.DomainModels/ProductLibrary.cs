using System;
using System.Collections.Generic;
using System.Text;

namespace MC.NetCore.DomainModels
{
    public partial class ProductLibrary
    {
        public int ProductId { get; set; }
        public int? SpId { get; set; }
        public int? CategoryId { get; set; }
        public string Plunum { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal? Price { get; set; }
        public decimal? MemberDiscount { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int? Mode { get; set; }
        public string UnitName { get; set; }
        public bool? IsMultiSpec { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Thumbnail { get; set; }
        public string PollingImg1 { get; set; }
        public string PollingImg2 { get; set; }
        public string PollingImg3 { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsOrganicFood { get; set; }
        public bool? IsImportFood { get; set; }
        public int? TypeId { get; set; }
        public string TypeIds { get; set; }
        public string TypeNames { get; set; }
        public int? MinQuantity { get; set; }
        public int? BaseSaleVolume { get; set; }
        public int? FactSaleVolume { get; set; }
        public decimal? AvgCommentScore { get; set; }
        public int? TotalStock { get; set; }
        public int? Ptype { get; set; }
        public bool? NeedPay { get; set; }
        public int? Cycle { get; set; }
        public string TimePrecision { get; set; }
        public int? OrderIndex { get; set; }
        public string Tags { get; set; }
        public decimal? LeastbuyMg { get; set; }
        public string Attributes { get; set; }
        public string QrcodeImg { get; set; }
        public string BookBeginTime { get; set; }
        public string BookEndTime { get; set; }
        public int? Astatus { get; set; }
        public DateTime? AcreateDate { get; set; }
        public DateTime? AmodifyDate { get; set; }
        public int? AspecialType { get; set; }
        public int? AsportsType { get; set; }
    }
}
