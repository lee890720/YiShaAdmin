using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 16:31
    /// 描 述：支付方式实体查询类
    /// </summary>
    public class PayListParam
    {
        public string PayName { get; set; }
        public string PayIds { get; set; }
    }
}
