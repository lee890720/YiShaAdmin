using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;
using System.ComponentModel;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-07 12:27
    /// 描 述：实体类
    /// </summary>
    [Table("HtlGroups")]
    public class GroupsEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("资源名称")]
        public string GroupName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("用途")]
        public string Purpose { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("联系人")]
        public string Contacts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("手机")]
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("微信")]
        public string Wechat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("区域")]
        public string Area { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("等级")]
        public int? Rank { get; set; }
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
        [Description("分类Id")]
        public long? CategoryId { get; set; }
        [NotMapped]
        [Description("分类")]
        public string CategoryName { get; set; }
    }
}
