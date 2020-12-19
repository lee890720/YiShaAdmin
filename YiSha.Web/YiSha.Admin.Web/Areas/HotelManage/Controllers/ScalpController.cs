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
    /// 日 期：2020-09-16 22:37
    /// 描 述：控制器类
    /// </summary>
    [Area("HotelManage")]
    public class ScalpController :  BaseController
    {
        private ScalpBLL scalpBLL = new ScalpBLL();

        #region 视图功能
        public ActionResult ScalpIndex()
        {
            return View();
        }

        public ActionResult ScalpForm()
        {
            return View();
        }
        public ActionResult ScalpClrIndex()
        {
            return View();
        }

        public ActionResult ScalpClrForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        public async Task<ActionResult> GetListJson(ScalpListParam param)
        {
            TData<List<ScalpEntity>> obj = await scalpBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(ScalpListParam param, Pagination pagination)
        {
            TData<List<ScalpEntity>> obj = await scalpBLL.GetPageList(param, pagination);

            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJsonForDay(ScalpListParam param, Pagination pagination)
        {
            TData<List<ScalpEntity>> obj = await scalpBLL.GetPageListForDay(param, pagination);

            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ScalpEntity> obj = await scalpBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(ScalpEntity entity)
        {
            TData<string> obj = await scalpBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> CheckFormJson(string ids)
        {
            TData obj = await scalpBLL.CheckForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> RepealFormJson(string ids)
        {
            TData obj = await scalpBLL.RepealForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await scalpBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ExportScalpJson(ScalpListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<ScalpEntity>> scalpObj = await scalpBLL.GetList(param);
            if (scalpObj.Tag == 1)
            {
                string file = new ExcelHelper<ScalpEntity>().ExportToExcel("推广列表.xls", "推广列表",scalpObj.Data,new string[] { "Id","OrderName","OrderNumber","StartDate","EndDate", "Commission", "TotalPrice","RealPrice","BranchName","CreateName","ModifierName" });
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }

        [HttpPost]
        public async Task<IActionResult> ExportScalpJson2(ScalpListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<ScalpEntity>> scalpObj = await scalpBLL.GetListForDay(param);
            if (scalpObj.Tag == 1)
            {
                string file = new ExcelHelper<ScalpEntity>().ExportToExcel("推广列表.xls", "推广列表", scalpObj.Data, new string[] { "Id", "OrderName", "OrderNumber", "StartDate", "EndDate", "Commission", "TotalPrice", "RealPrice", "BranchName", "CreateName", "ModifierName" });
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
    }
}
