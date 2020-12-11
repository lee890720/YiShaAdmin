using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiSha.Model.Result.HotelManage
{
    public class SaleData { }
    public class SaleBarData
    {
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        [Display(Name = "日期")]
        public string StartDate { get; set; }
        [Display(Name = "销售额")]
        public decimal? Sale { get; set; }
        [Display(Name = "净利润")]
        public decimal? Equity { get; set; }
        [Display(Name = "销售成本")]
        public decimal? Cost { get; set; }
        [Display(Name = "销售量")]
        public decimal? Total { get; set; }
    }

    public class SalePieData
    {
        [Display(Name = "产品")]
        public string Product { get; set; }
        [Display(Name = "数量")]
        public int? Total { get; set; }
    }

}
