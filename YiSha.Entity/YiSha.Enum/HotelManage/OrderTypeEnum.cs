using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiSha.Enum.HotelManage
{
    public enum OrderTypeEnum
    {

        [Description("预订")]
        Order1 = 0,

        [Description("入住")]
        Order2 = 1,

        [Description("退房")]
        Order3 = 2,

        [Description("取消")]
        Order4 = 3,
    }

    public enum HouseTypeEnum
    {

        [Description("净房")]
        House1 = 0,

        [Description("脏房")]
        House2 = 1,

        [Description("维修")]
        House3 = 2,
    }

    public enum CheckTypeEnum
    {

        [Description("未审核")]
        Check1 = 0,

        [Description("已审核")]
        Check2 = 1,
    }
}
