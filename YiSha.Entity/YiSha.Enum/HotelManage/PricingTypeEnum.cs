using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace YiSha.Enum.HotelManage
{
    public enum PricingTypeEnum
    {
        [Description("相加")]
        Mode0 = 0,

        [Description("相乘")]
        Mode1 = 1
    }
}
