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
    public class OrderController :  BaseController
    {
        private OrderBLL orderBLL = new OrderBLL();

        #region 视图功能
        public ActionResult OrderIndex()
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
        public async Task<ActionResult> GetListJson(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJson2(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetList2(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJson3(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetList3(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson2(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetPageList2(param, pagination);

            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //return Json(obj, settings);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson3(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = await orderBLL.GetPageList3(param, pagination);
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
            TData<List<OrderEntity>> orderObj = await orderBLL.GetList2(param);
            if (orderObj.Tag == 1)
            {
                string file = new ExcelHelper<OrderEntity>().ExportToExcel("订单列表.xls", "订单列表",orderObj.Data,new string[] { "Id","OrderName","Nickname","Phone","OrderNumber","HouseType","HouseNumber","StartDate","EndDate","UnitPrice","TotalPrice","HouseCount","StewardName","ChannelName","BranchName","CreateName","ModifierName" ,"State"});
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
    }
}
