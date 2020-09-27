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
    public class OrderListParam
    {
        public long? Id { get; set; }
        public string OrderName { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string OrderNumber { get; set; }
        public long? HouseTypeId { get; set; }
        public long? HouseNumberId { get; set; }
        public long? BranchId { get; set; }
        public int? IsFinish { get; set; }
        public int? IsFinance { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OrderIds { get; set; }
    }
}
