using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-12-11 18:57
    /// 描 述：实体查询类
    /// </summary>
    public class MemoListParam
    {
        public long? Id { get;set; }
        public DateTime? ExecuteDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Memo { get; set; }
        public long? StewardId { get; set; }
        public long? BranchId { get; set; }
        public int? IsFinish { get; set; }
        public string MemoIds { get; set; }
    }
}
