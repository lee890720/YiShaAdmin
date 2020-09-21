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
    /// 日 期：2020-07-04 11:14
    /// 描 述：收款记录控制器类
    /// </summary>
    [Area("HotelManage")]
    public class ProceedsController :  BaseController
    {
        private ProceedsBLL proceedsBLL = new ProceedsBLL();

        #region 视图功能
        public ActionResult ProceedsIndex()
        {
            return View();
        }

        public ActionResult ProceedsForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        public async Task<ActionResult> GetListJson(ProceedsListParam param)
        {
            TData<List<ProceedsEntity>> obj = await proceedsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(ProceedsListParam param, Pagination pagination)
        {
            TData<List<ProceedsEntity>> obj = await proceedsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson2(ProceedsListParam param, Pagination pagination)
        {
            TData<List<ProceedsEntity>> obj = await proceedsBLL.GetPageList2(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ProceedsEntity> obj = await proceedsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(ProceedsEntity entity)
        {
            TData<string> obj = await proceedsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await proceedsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
