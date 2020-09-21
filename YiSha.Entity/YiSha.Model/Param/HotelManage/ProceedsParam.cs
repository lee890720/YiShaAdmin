using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-04 11:14
    /// 描 述：收款记录实体查询类
    /// </summary>
    public class ProceedsListParam
    {
        public string ProceedsName { get; set; }
        public string ProceedsIds { get; set; }
        public string BranchName { get; set; }
        public long? OrderId { get; set; }
    }
}
