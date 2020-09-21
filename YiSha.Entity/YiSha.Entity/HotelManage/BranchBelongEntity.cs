using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 19:18
    /// 描 述：门店属性实体类
    /// </summary>
    [Table("HtlBranchBelong")]
    public class BranchBelongEntity : BaseCreateEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? BranchId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? BelongId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? BelongType { get; set; }

        [NotMapped]
        public string BranchIds { get; set; }
    }
}
