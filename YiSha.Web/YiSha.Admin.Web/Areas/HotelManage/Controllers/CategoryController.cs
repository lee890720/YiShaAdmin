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
    /// 日 期：2020-11-06 20:38
    /// 描 述：控制器类
    /// </summary>
    [Area("HotelManage")]
    public class CategoryController :  BaseController
    {
        private CategoryBLL categoryBLL = new CategoryBLL();

        #region 视图功能
        [AuthorizeFilter("hotel:category:view")]
        public ActionResult CategoryIndex()
        {
            return View();
        }

        public ActionResult CategoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        //[AuthorizeFilter("hotel:category:search")]
        public async Task<ActionResult> GetListJson(CategoryListParam param)
        {
            TData<List<CategoryEntity>> obj = await categoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        //[AuthorizeFilter("hotel:category:search")]
        public async Task<ActionResult> GetPageListJson(CategoryListParam param, Pagination pagination)
        {
            TData<List<CategoryEntity>> obj = await categoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<CategoryEntity> obj = await categoryBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hotel:category:add,hotel:category:edit")]
        public async Task<ActionResult> SaveFormJson(CategoryEntity entity)
        {
            TData<string> obj = await categoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hotel:category:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await categoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
