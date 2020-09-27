using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-24 11:14
    /// 描 述：实体查询类
    /// </summary>
    public class NoteListParam
    {
        public string Account { get; set; }
        public long? BranchId { get; set; }
        public string NoteIds { get; set; }
    }
}
