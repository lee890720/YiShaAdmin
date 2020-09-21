using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 16:31
    /// 描 述：支付方式实体类
    /// </summary>
    [Table("HtlPay")]
    public class PayEntity : BaseCreateEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PayName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? PaySort { get; set; }
    }
}
