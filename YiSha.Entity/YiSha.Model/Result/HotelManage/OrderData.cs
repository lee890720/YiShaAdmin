using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiSha.Model.Result.HotelManage
{
    public class OrderData { }
    public class OrderBarData
    {
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        [Display(Name = "日期")]
        public string StartDate { get; set; }
        [Display(Name = "房收")]
        public decimal? HouseAmount { get; set; }
        [Display(Name = "总间夜")]
        public int? HouseTotal { get; set; }
        [Display(Name = "已售间夜")]
        public int? HouseCount { get; set; }
        [Display(Name = "出租率")]
        public double? Rate { get; set; }
        [Display(Name = "均价")]
        public decimal? Average { get; set; }
        [Display(Name = "有效均价")]
        public decimal? ValidAverage { get; set; }
    }

    public class OrderPieData
    {
        [Display(Name = "渠道")]
        public string Channel { get; set; }
        [Display(Name = "间夜数")]
        public int? CTotal { get; set; }
        [Display(Name = "总金额")]
        public decimal? ATotal { get; set; }
    }

}
