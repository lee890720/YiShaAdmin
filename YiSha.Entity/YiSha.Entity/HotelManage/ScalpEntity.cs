using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

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
        public string OrderName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string HouseNumber { get; set; }
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
        public decimal? Commission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? TotalPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? RealPrice { get; set; }
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
        public long? BranchId { get; set; }
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ChannelId { get; set; }
        [NotMapped]
        public string BranchName { get; set; }
        [NotMapped]
        public string CreateName { get; set; }
        [NotMapped]
        public string ModifierName { get; set; }
        [NotMapped]
        public string ChannelName { get; set; }
        [NotMapped]
        public string ChannelColor { get; set; }
    }
}
