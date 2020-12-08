using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;
using System.Collections.Generic;
using System.ComponentModel;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-04 16:47
    /// 描 述：房态订单实体类
    /// </summary>
    [Table("HtlSale")]
    public class SaleEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        [Description("发生日期")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("客人名称")]
        public string SaleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("手机")]
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("身份证号")]
        public string IDNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("销售价")]
        public decimal? SalePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("采购价")]
        public decimal? PurchasePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("利润")]
        public decimal? Profit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("净利润")]
        public decimal? Equity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("管家提成")]
        public decimal? Commission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("预审核")]
        public int? IsFinish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("财务审核")]
        public int? IsFinance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("列号")]
        public int? Sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? StewardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ProductId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? BranchId { get; set; }
        [NotMapped]
        [Description("门店")]
        public string BranchName { get; set; }
        [NotMapped]
        [Description("产品")]
        public string ProductName { get; set; }
        [NotMapped]
        [Description("创建人")]
        public string CreateName { get; set; }
        [NotMapped]
        [Description("修改人")]
        public string ModifierName { get; set; }
        [NotMapped]
        [Description("管家")]
        public string StewardName { get; set; }
        [NotMapped]
        public DateTime? StartDate { get; set; }
        [NotMapped]
        public DateTime? EndDate { get; set; }
    }
}
