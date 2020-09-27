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
    /// 日 期：2020-09-24 13:11
    /// 描 述：控制器类
    /// </summary>
    [Area("HotelManage")]
    public class PricingController :  BaseController
    {
        private PricingBLL pricingBLL = new PricingBLL();

        #region 视图功能
        [AuthorizeFilter("hotel:pricing:view")]
        public ActionResult PricingIndex()
        {
            return View();
        }

        public ActionResult PricingForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hotel:pricing:search")]
        public async Task<ActionResult> GetListJson(PricingListParam param)
        {
            TData<List<PricingEntity>> obj = await pricingBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hotel:pricing:search")]
        public async Task<ActionResult> GetPageListJson(PricingListParam param, Pagination pagination)
        {
            TData<List<PricingEntity>> obj = await pricingBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PricingEntity> obj = await pricingBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hotel:pricing:add,hotel:pricing:edit")]
        public async Task<ActionResult> SaveFormJson(PricingEntity entity)
        {
            TData<string> obj = await pricingBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hotel:pricing:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await pricingBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
