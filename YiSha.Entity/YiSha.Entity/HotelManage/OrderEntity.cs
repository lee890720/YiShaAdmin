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
    [Table("HtlOrder")]
    public class OrderEntity : BaseExtensionEntity
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
        [Description("昵称")]
        public string Nickname { get; set; }
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
        [Description("订单号")]
        public string OrderNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        [Description("房型")]
        public long? HouseTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        [Description("房号")]
        public long? HouseNumberId { get; set; }
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
        [Description("单价")]
        public decimal? UnitPrice { get; set; }
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
        [Description("间夜数")]
        public int? HouseCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("订单状态")]
        public int? State { get; set; }
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
        public long? StewardId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        [Description("渠道")]
        public long? ChannelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        [Description("门店")]
        public long? BranchId { get; set; }
        [NotMapped]
        [Description("门店")]
        public string BranchName { get; set; }
        [NotMapped]
        [Description("房型")]
        public string HouseType { get; set; }
        [NotMapped]
        [Description("房号")]
        public string HouseNumber { get; set; }
        [NotMapped]
        [Description("渠道")]
        public string ChannelName { get; set; }
        [NotMapped]
        [Description("颜色")]
        public string ChannelColor { get; set; }
        [NotMapped]
        [Description("创建人")]
        public string CreateName { get; set; }
        [NotMapped]
        [Description("修改人")]
        public string ModifierName { get; set; }
        [NotMapped]
        [Description("管家")]
        public string StewardName { get; set; }
    }
}
