using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 19:04
    /// 描 述：门店信息实体查询类
    /// </summary>
    public class BranchListParam
    {
        public string BranchName { get; set; }
        public int BranchLevel { get; set; }
        public string Ids { get; set; }
    }
}
