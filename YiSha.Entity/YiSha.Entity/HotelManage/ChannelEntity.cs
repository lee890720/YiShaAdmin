using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 18:39
    /// 描 述：预订渠道实体类
    /// </summary>
    [Table("HtlChannel")]
    public class ChannelEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ChannelName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ChannelColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? ChannelSort { get; set; }
    }
}
