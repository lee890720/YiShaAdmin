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
        private SaleBLL SaleBLL = new SaleBLL();

        #region 视图功能
        public ActionResult SaleIndex()
        {
            return View();
        }

        public ActionResult SaleDelIndex()
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
            TData<List<SaleEntity>> obj = await SaleBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(SaleListParam param, Pagination pagination)
        {
            TData<List<SaleEntity>> obj = await SaleBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJson2(SaleListParam param)
        {
            TData<List<SaleEntity>> obj = await SaleBLL.GetList2(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson2(SaleListParam param, Pagination pagination)
        {
            TData<List<SaleEntity>> obj = await SaleBLL.GetPageList2(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<SaleEntity> obj = await SaleBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(SaleEntity entity)
        {
            TData<string> obj = await SaleBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> CheckFormJson(string ids)
        {
            TData obj = await SaleBLL.CheckForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> RepealFormJson(string ids)
        {
            TData obj = await SaleBLL.RepealForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await SaleBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ExportSaleJson(SaleListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<SaleEntity>> SaleObj = await SaleBLL.GetList2(param);
            if (SaleObj.Tag == 1)
            {
                string file = new ExcelHelper<SaleEntity>().ExportToExcel("外销列表.xls", "外销列表",SaleObj.Data,new string[] { "Id", "CreateDate","SaleName","Phone","IDNumber", "ProductName", "SalePrice","PurchasePrice","Profit","Equity","Commission","StewardName","BranchName","CreateName","ModifierName"});
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
    }
}