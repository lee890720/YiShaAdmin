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
    /// 日 期：2020-11-07 12:27
    /// 描 述：控制器类
    /// </summary>
    [Area("HotelManage")]
    public class GroupsController :  BaseController
    {
        private GroupsBLL groupsBLL = new GroupsBLL();

        #region 视图功能
        [AuthorizeFilter("hotel:groups:view")]
        public ActionResult GroupsIndex()
        {
            return View();
        }

        public ActionResult GroupsForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("hotel:groups:search")]
        public async Task<ActionResult> GetListJson(GroupsListParam param)
        {
            TData<List<GroupsEntity>> obj = await groupsBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("hotel:groups:search")]
        public async Task<ActionResult> GetPageListJson(GroupsListParam param, Pagination pagination)
        {
            TData<List<GroupsEntity>> obj = await groupsBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<GroupsEntity> obj = await groupsBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("hotel:groups:add,hotel:groups:edit")]
        public async Task<ActionResult> SaveFormJson(GroupsEntity entity)
        {
            TData<string> obj = await groupsBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("hotel:groups:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await groupsBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ExportGroupsJson(GroupsListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<GroupsEntity>> groupsObj = await groupsBLL.GetList(param);
            if (groupsObj.Tag == 1)
            {
                string file = new ExcelHelper<GroupsEntity>().ExportToExcel("资源列表.xls", "资源列表", groupsObj.Data, new string[] {  "GroupName", "Purpose", "Contacts", "Phone", "Wechat",  "Area","Rank",  "Remark"});
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
    }
}
