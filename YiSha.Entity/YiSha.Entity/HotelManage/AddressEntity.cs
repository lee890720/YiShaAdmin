using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-24 13:10
    /// 描 述：实体类
    /// </summary>
    [Table("HtlAddress")]
    public class AddressEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AddressName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string WeChat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Purpose { get; set; }
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
