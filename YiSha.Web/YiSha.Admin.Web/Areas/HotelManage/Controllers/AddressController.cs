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
    /// 日 期：2020-09-24 13:10
    /// 描 述：控制器类
    /// </summary>
    [Area("HotelManage")]
    public class AddressController :  BaseController
    {
        private AddressBLL addressBLL = new AddressBLL();

        #region 视图功能
        [AuthorizeFilter("hotel:address:view")]
        public ActionResult AddressIndex()
        {
            return View();
        }

        public ActionResult AddressForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hotel:address:search")]
        public async Task<ActionResult> GetListJson(AddressListParam param)
        {
            TData<List<AddressEntity>> obj = await addressBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hotel:address:search")]
        public async Task<ActionResult> GetPageListJson(AddressListParam param, Pagination pagination)
        {
            TData<List<AddressEntity>> obj = await addressBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<AddressEntity> obj = await addressBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hotel:address:add,hotel:address:edit")]
        public async Task<ActionResult> SaveFormJson(AddressEntity entity)
        {
            TData<string> obj = await addressBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hotel:address:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await addressBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
