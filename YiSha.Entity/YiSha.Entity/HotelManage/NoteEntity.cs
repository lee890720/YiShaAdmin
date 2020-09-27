using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-24 11:14
    /// 描 述：实体类
    /// </summary>
    [Table("HtlNote")]
    public class NoteEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Platform { get; set; }
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
        [NotMapped]
        public string BranchName { get; set; }
        [NotMapped]
        public string CreateName { get; set; }
        [NotMapped]
        public string ModifierName { get; set; }
    }
}
