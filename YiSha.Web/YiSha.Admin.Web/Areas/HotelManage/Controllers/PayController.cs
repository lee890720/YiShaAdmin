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
    /// 日 期：2020-07-03 16:31
    /// 描 述：支付方式控制器类
    /// </summary>
    [Area("HotelManage")]
    public class PayController :  BaseController
    {
        private PayBLL PayBLL = new PayBLL();

        #region 视图功能
        public ActionResult PayIndex()
        {
            return View();
        }

        public ActionResult PayForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        public async Task<ActionResult> GetListJson(PayListParam param)
        {
            TData<List<PayEntity>> obj = await PayBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(PayListParam param, Pagination pagination)
        {
            TData<List<PayEntity>> obj = await PayBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PayEntity> obj = await PayBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(PayEntity entity)
        {
            TData<string> obj = await PayBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await PayBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
