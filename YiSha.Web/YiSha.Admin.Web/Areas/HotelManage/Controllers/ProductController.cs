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
using YiSha.Model.Param;

namespace YiSha.Admin.Web.Areas.HotelManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-06 20:39
    /// 描 述：控制器类
    /// </summary>
    [Area("HotelManage")]
    public class ProductController :  BaseController
    {
        private ProductBLL productBLL = new ProductBLL();

        #region 视图功能
        [AuthorizeFilter("hotel:product:view")]
        public ActionResult ProductIndex()
        {
            return View();
        }

        public ActionResult ProductForm()
        {
            return View();
        }

        public IActionResult ProductImport()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hotel:product:search")]
        public async Task<ActionResult> GetListJson(ProductListParam param)
        {
            TData<List<ProductEntity>> obj = await productBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hotel:product:search")]
        public async Task<ActionResult> GetPageListJson(ProductListParam param, Pagination pagination)
        {
            TData<List<ProductEntity>> obj = await productBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ProductEntity> obj = await productBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hotel:product:add,hotel:product:edit")]
        public async Task<ActionResult> SaveFormJson(ProductEntity entity)
        {
            TData<string> obj = await productBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hotel:product:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await productBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ImportProductJson(ImportParam param)
        {
            List<ProductEntity> list = new ExcelHelper<ProductEntity>().ImportFromExcel(param.FilePath);
            TData obj = await productBLL.ImportProduct(param, list);
            return Json(obj);
        }

        [HttpPost]
        public async Task<IActionResult> ExportProductJson(ProductListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<ProductEntity>> productObj = await productBLL.GetList(param);
            if (productObj.Tag == 1)
            {
                string file = new ExcelHelper<ProductEntity>().ExportToExcel("产品列表.xls", "产品列表", productObj.Data, new string[] { "Id", "ProductName", "Specification", "Unit", "CategoryName", "GroupIds",  "SalePrice", "PurchasePrice", "Sort","Remark", "CategoryId"});
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
    }
}
