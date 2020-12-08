using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 14:09
    /// 描 述：房态订单实体查询类
    /// </summary>
    public class SaleListParam
    {
        public DateTime? CreateDate { get; set; }
        public long? Id { get; set; }
        public string SaleName { get; set; }
        public string Phone { get; set; }
        public string IDNumber { get; set; }
        public long? ProductId { get; set; }
        public long? BranchId { get; set; }
        public int? IsFinish { get; set; }
        public int? IsFinance { get; set; }
        public string SaleIds { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
