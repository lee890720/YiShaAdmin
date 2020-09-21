using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;
using System.Collections.Generic;

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
        public string OrderName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Nickname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? HouseTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? HouseNumberId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? TotalPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? HouseCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? IsFinish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? IsFinance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        public long? ChannelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? BranchId { get; set; }
        [NotMapped]
        public string BranchName { get; set; }
        [NotMapped]
        public string HouseType { get; set; }
        [NotMapped]
        public string HouseNumber { get; set; }
        [NotMapped]
        public string ChannelName { get; set; }
        [NotMapped]
        public string ChannelColor { get; set; }
        [NotMapped]
        public string CreateName { get; set; }
        [NotMapped]
        public string ModifierName { get; set; }
        [NotMapped]
        public string StewardName { get; set; }
    }
}
