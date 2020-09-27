using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-24 13:11
    /// 描 述：实体类
    /// </summary>
    [Table("HtlPricing")]
    public class PricingEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string HouseName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Shop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Ota { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? OtaBase { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? OtaPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Travel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Team { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Inner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? Peak { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Mode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Sequence { get; set; }
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
    }
}
