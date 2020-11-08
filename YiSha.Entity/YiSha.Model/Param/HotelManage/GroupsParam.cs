using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-07 12:27
    /// 描 述：实体查询类
    /// </summary>
    public class GroupsListParam
    {
        public string GroupName { get; set; }
        public string GroupIds { get; set; }
        public string CategoryName { get; set; }
        public long? CategoryId { get; set; }
        public string Area { get; set; }
        public int? Rank { get; set; }
    }
}
