using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;
using System.ComponentModel;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-12-11 18:57
    /// 描 述：实体类
    /// </summary>
    [Table("HtlMemo")]
    public class MemoEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? ExecuteDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Memo { get; set; }
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
        public int? IsFinish { get; set; }
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
