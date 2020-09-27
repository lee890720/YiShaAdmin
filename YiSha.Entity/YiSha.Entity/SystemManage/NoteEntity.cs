using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.SystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-27 17:21
    /// 描 述：实体类
    /// </summary>
    [Table("SysNote")]
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
    }
}
