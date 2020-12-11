using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.HotelManage;
using YiSha.Business.HotelManage;
using YiSha.Model.Param.HotelManage;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using YiSha.Model.Result.HotelManage;

namespace YiSha.Admin.Web.Areas.HotelManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-04 16:47
    /// 描 述：房态订单控制器类
    /// </summary>
    [Area("HotelManage")]
    public class SaleController :  BaseController
    {
        private SaleBLL saleBLL = new SaleBLL();

        #region 视图功能
        public ActionResult SaleIndex()
        {
            return View();
        }

        public ActionResult SaleDelIndex()
        {
            return View();
        }

        public ActionResult SaleAnalyse()
        {
            return View();
        }

        public ActionResult SaleForm()
        {
            return View();
        }

        public ActionResult CalendarIndex()
        {
            return View();
        }

        public ActionResult CalendarForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        public async Task<ActionResult> GetListJson(SaleListParam param)
        {
            TData<List<SaleEntity>> obj = await saleBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(SaleListParam param, Pagination pagination)
        {
            TData<List<SaleEntity>> obj = await saleBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        public async Task<ActionResult> GetPageListJsonForDay(SaleListParam param, Pagination pagination)
        {
            TData<List<SaleEntity>> obj = await saleBLL.GetPageListForDay(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForDailyData(SaleListParam param)
        {
            TData<List<SaleBarData>> obj = await saleBLL.GetListForDailyData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForMonthData(SaleListParam param)
        {
            TData<List<SaleBarData>> obj = await saleBLL.GetListForMonthData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForYearData(SaleListParam param)
        {
            TData<SaleBarData> obj = await saleBLL.GetListForYearData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForPieMonthData(SaleListParam param)
        {
            TData<List<SalePieData>> obj = await saleBLL.GetListForPieMonthData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForPieYearData(SaleListParam param)
        {
            TData<List<SalePieData>> obj = await saleBLL.GetListForPieYearData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<SaleEntity> obj = await saleBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(SaleEntity entity)
        {
            TData<string> obj = await saleBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> CheckFormJson(string ids)
        {
            TData obj = await saleBLL.CheckForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> RepealFormJson(string ids)
        {
            TData obj = await saleBLL.RepealForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await saleBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ExportSaleJson(SaleListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<SaleEntity>> SaleObj = await saleBLL.GetList(param);
            if (SaleObj.Tag == 1)
            {
                string file = new ExcelHelper<SaleEntity>().ExportToExcel("外销列表.xls", "外销列表",SaleObj.Data,new string[] { "Id", "CreateDate","SaleName","Phone","IDNumber", "ProductName", "SalePrice","PurchasePrice","Profit","Equity","Commission","StewardName","BranchName","CreateName","ModifierName"});
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }

        [HttpPost]
        public async Task<IActionResult> ExportSaleJson2(SaleListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<SaleEntity>> SaleObj = await saleBLL.GetListForDay(param);
            if (SaleObj.Tag == 1)
            {
                string file = new ExcelHelper<SaleEntity>().ExportToExcel("外销列表.xls", "外销列表", SaleObj.Data, new string[] { "Id", "CreateDate", "SaleName", "Phone", "IDNumber", "ProductName", "SalePrice", "PurchasePrice", "Profit", "Equity", "Commission", "StewardName", "BranchName", "CreateName", "ModifierName" });
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
    }
}