using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace YiSha.Enum.HotelManage
{
    public enum BranchTypeEnum
    {
        [Description("未清理")]
        Clean0 = 0,

        [Description("已清理")]
        Clean1 = 1
    }
}
