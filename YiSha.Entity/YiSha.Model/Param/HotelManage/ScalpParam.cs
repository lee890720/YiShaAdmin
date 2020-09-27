using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-16 22:37
    /// 描 述：实体查询类
    /// </summary>
    public class ScalpListParam
    {
        public long? Id { get; set; }
        public string OrderName { get; set; }
        public string OrderNumber { get; set; }
        public long? BranchId { get; set; }
        public int? IsFinish { get; set; }
        public int? IsFinance { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OrderIds { get; set; }
    }
}
