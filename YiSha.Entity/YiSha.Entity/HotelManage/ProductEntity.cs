using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace YiSha.Entity.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-10-12 10:23
    /// 描 述：实体类
    /// </summary>
    [Table("HtlProduct")]
    public class ProductEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("产品名称")]
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("规格")]
        public string Specification { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("单位")]
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("销售价")]
        public decimal? SalePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("采购价")]
        public decimal? PurchasePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("顺序")]
        public int? Sort { get; set; }
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
        [NotMapped]
        [Description("客户群")]
        public string GroupIds { get; set; }
    }
}
