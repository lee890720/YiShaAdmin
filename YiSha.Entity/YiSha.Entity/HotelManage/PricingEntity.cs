using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;
using System.ComponentModel;

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
        [Description("房型名")]
        public string HouseName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("门店价")]
        public int? Shop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("线上价")]
        public int? Ota { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("预付底价")]
        public decimal? OtaBase { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("现付价")]
        public int? OtaPay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("合作价")]
        public int? Travel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("团队价")]
        public int? Team { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("内部价")]
        public int? Inner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("旺季基数")]
        public decimal? Peak { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("模式")]
        public int? Mode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("顺序")]
        public int? Sequence { get; set; }
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
    }
}
