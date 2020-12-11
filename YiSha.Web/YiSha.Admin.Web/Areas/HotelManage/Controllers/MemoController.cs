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

namespace YiSha.Admin.Web.Areas.HotelManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-12-11 18:57
    /// 描 述：控制器类
    /// </summary>
    [Area("HotelManage")]
    public class MemoController :  BaseController
    {
        private MemoBLL memoBLL = new MemoBLL();

        #region 视图功能
        public ActionResult MemoIndex()
        {
            return View();
        }

        public ActionResult MemoForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        public async Task<ActionResult> GetListJson(MemoListParam param)
        {
            TData<List<MemoEntity>> obj = await memoBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(MemoListParam param, Pagination pagination)
        {
            TData<List<MemoEntity>> obj = await memoBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MemoEntity> obj = await memoBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(MemoEntity entity)
        {
            TData<string> obj = await memoBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await memoBLL.DeleteForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> CheckFormJson(string ids)
        {
            TData obj = await memoBLL.CheckForm(ids);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> RepealFormJson(string ids)
        {
            TData obj = await memoBLL.RepealForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
