using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 18:30
    /// 描 述：预订渠道实体查询类
    /// </summary>
    public class ChannelListParam
    {
        public string ChannelName { get; set; }
        public string ChannelIds { get; set; }
    }
}
