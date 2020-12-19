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
using YiSha.Model.Result.HotelManage;
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
    public class OrderController :  BaseController
    {
        private OrderBLL orderBLL = new OrderBLL();

        #region 视图功能
        public ActionResult OrderIndex()
        {
            return View();
        }
        public ActionResult CalendarIndex()
        {
            return View();
        }

        public ActionResult OrderAnalyse()
        {
            return View();
        }

        public ActionResult OrderDelIndex()
        {
            return View();
        }

        public ActionResult OrderForm()
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
        //CalendarIndex
        public async Task<ActionResult> GetListJson(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        //OrderIndex
        public async Task<ActionResult> GetPageListJson(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        //OrderDelIndex
        public async Task<ActionResult> GetPageListJsonForDel(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetPageListForDel(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        //OrderAnalyse
        public async Task<ActionResult> GetPageListJsonForDay(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetPageListForDay(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForDailyData(OrderListParam param)
        {
            TData<List<OrderBarData>> obj = await orderBLL.GetListForDailyData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForMonthData(OrderListParam param)
        {
            TData<List<OrderBarData>> obj = await orderBLL.GetListForMonthData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForYearData(OrderListParam param)
        {
            TData<OrderBarData> obj = await orderBLL.GetListForYearData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForPieMonthData(OrderListParam param)
        {
            TData<List<OrderPieData>> obj = await orderBLL.GetListForPieMonthData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJsonForPieYearData(OrderListParam param)
        {
            TData<List<OrderPieData>> obj = await orderBLL.GetListForPieYearData(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<OrderEntity> obj = await orderBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(OrderEntity entity)
        {
            TData<string> obj = await orderBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> CheckFormJson(string ids)
        {
            TData obj = await orderBLL.CheckForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> RepealFormJson(string ids)
        {
            TData obj = await orderBLL.RepealForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await orderBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ExportOrderJson(OrderListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<OrderEntity>> orderObj = await orderBLL.GetList(param);
            if (orderObj.Tag == 1)
            {
                string file = new ExcelHelper<OrderEntity>().ExportToExcel("住宿列表.xls", "住宿列表", orderObj.Data,new string[] { "Id","OrderName","Nickname","Phone","OrderNumber","HouseType","HouseNumber","StartDate","EndDate","UnitPrice","TotalPrice","HouseCount","StewardName","ChannelName","BranchName","CreateName","ModifierName" ,"State"});
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }

        [HttpPost]
        public async Task<IActionResult> ExportOrderJson2(OrderListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<OrderEntity>> orderObj = await orderBLL.GetListForDay(param);
            if (orderObj.Tag == 1)
            {
                string file = new ExcelHelper<OrderEntity>().ExportToExcel("住宿列表.xls", "住宿列表", orderObj.Data, new string[] { "Id", "OrderName", "Nickname", "Phone", "OrderNumber", "HouseType", "HouseNumber", "StartDate", "EndDate", "UnitPrice", "TotalPrice", "HouseCount", "StewardName", "ChannelName", "BranchName", "CreateName", "ModifierName", "State" });
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
    }
}
