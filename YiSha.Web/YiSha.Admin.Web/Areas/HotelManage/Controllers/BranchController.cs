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
using YiSha.Model.Result;

namespace YiSha.Admin.Web.Areas.HotelManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 19:04
    /// 描 述：门店信息控制器类
    /// </summary>
    [Area("HotelManage")]
    public class BranchController :  BaseController
    {
        private BranchBLL branchBLL = new BranchBLL();

        #region 视图功能
        public ActionResult BranchIndex()
        {
            return View();
        }

        public ActionResult BranchForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        public async Task<ActionResult> GetListJson(BranchListParam param)
        {
            param.Status = 1;
            TData<List<BranchEntity>> obj = await branchBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetListJson2(BranchListParam param)
        {
            TData<List<BranchEntity>> obj = await branchBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(BranchListParam param, Pagination pagination)
        {
            param.Status = 1;
            TData<List<BranchEntity>> obj = await branchBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetBranchTreeListJson(BranchListParam param)
        {
            param.Status = 1;
            TData<List<ZtreeInfo>> obj = await branchBLL.GetZtreeBranchList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<BranchEntity> obj = await branchBLL.GetEntity(id);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson()
        {
            TData<int> obj = await branchBLL.GetMaxSort();
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(BranchEntity entity)
        {
            TData<string> obj = await branchBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await branchBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
