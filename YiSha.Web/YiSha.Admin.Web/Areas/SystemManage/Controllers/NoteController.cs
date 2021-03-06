﻿using System;
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
using YiSha.Entity.SystemManage;
using YiSha.Business.SystemManage;
using YiSha.Model.Param.SystemManage;

namespace YiSha.Admin.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-27 17:21
    /// 描 述：控制器类
    /// </summary>
    [Area("SystemManage")]
    public class NoteController :  BaseController
    {
        private NoteBLL noteBLL = new NoteBLL();

        #region 视图功能
        [AuthorizeFilter("system:note:view")]
        public ActionResult NoteIndex()
        {
            return View();
        }

        public ActionResult NoteForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("system:note:search")]
        public async Task<ActionResult> GetListJson(NoteListParam param)
        {
            TData<List<NoteEntity>> obj = await noteBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("system:note:search")]
        public async Task<ActionResult> GetPageListJson(NoteListParam param, Pagination pagination)
        {
            TData<List<NoteEntity>> obj = await noteBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<NoteEntity> obj = await noteBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("system:note:add,system:note:edit")]
        public async Task<ActionResult> SaveFormJson(NoteEntity entity)
        {
            TData<string> obj = await noteBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:note:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await noteBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
