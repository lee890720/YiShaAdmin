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
    /// 日 期：2020-10-12 10:23
    /// 描 述：控制器类
    /// </summary>
    [Area("HotelManage")]
    public class PriceController :  BaseController
    {
        private PriceBLL priceBLL = new PriceBLL();

        #region 视图功能
        [AuthorizeFilter("hotel:price:view")]
        public ActionResult PriceIndex()
        {
            return View();
        }

        public ActionResult PriceForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hotel:price:search")]
        public async Task<ActionResult> GetListJson(PriceListParam param)
        {
            TData<List<PriceEntity>> obj = await priceBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hotel:price:search")]
        public async Task<ActionResult> GetPageListJson(PriceListParam param, Pagination pagination)
        {
            TData<List<PriceEntity>> obj = await priceBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PriceEntity> obj = await priceBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hotel:price:add,hotel:price:edit")]
        public async Task<ActionResult> SaveFormJson(PriceEntity entity)
        {
            TData<string> obj = await priceBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hotel:price:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await priceBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
