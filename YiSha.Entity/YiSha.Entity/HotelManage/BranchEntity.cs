using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 19:04
    /// 描 述：门店信息实体类
    /// </summary>
    [Table("HtlBranch")]
    public class BranchEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ParentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BranchName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? HouseCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BranchArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? BranchSort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? BranchLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? IsClean { get; set; }

        /// <summary>
        /// 多个部门Id
        /// </summary>
        [NotMapped]
        public string Ids { get; set; }
        [NotMapped]
        public string ChannelIds { get; set; }
        [NotMapped]
        public string PayIds { get; set; }
    }
}
