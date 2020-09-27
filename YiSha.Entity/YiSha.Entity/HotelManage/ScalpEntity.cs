using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;
using System.ComponentModel;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-16 22:37
    /// 描 述：实体类
    /// </summary>
    [Table("HtlScalp")]
    public class ScalpEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("订单名")]
        public string OrderName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("订单号")]
        public string OrderNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("房号")]
        public string HouseNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        [Description("入住日期")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        [Description("离店日期")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("佣金")]
        public decimal? Commission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("总价")]
        public decimal? TotalPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("底价")]
        public decimal? RealPrice { get; set; }
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
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? BranchId { get; set; }
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ChannelId { get; set; }
        [NotMapped]
        [Description("门店")]
        public string BranchName { get; set; }
        [NotMapped]
        [Description("创建人")]
        public string CreateName { get; set; }
        [NotMapped]
        [Description("修改人")]
        public string ModifierName { get; set; }
        [NotMapped]
        [Description("渠道")]
        public string ChannelName { get; set; }
        [NotMapped]
        public string ChannelColor { get; set; }
    }
}
