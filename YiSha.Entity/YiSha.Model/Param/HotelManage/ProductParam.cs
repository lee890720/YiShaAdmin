using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-10-12 10:23
    /// 描 述：实体查询类
    /// </summary>
    public class ProductListParam
    {
        public string ProductName { get; set; }
        public string GroupIds { get; set; }
        public string CategoryName { get; set; }
        public long? CategoryId { get; set; }
        public string ProductIds { get; set; }
    }
}
