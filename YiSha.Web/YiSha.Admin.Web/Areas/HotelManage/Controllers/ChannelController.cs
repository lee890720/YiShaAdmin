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
    /// 日 期：2020-07-03 18:39
    /// 描 述：预订渠道控制器类
    /// </summary>
    [Area("HotelManage")]
    public class ChannelController :  BaseController
    {
        private ChannelBLL channelBLL = new ChannelBLL();

        #region 视图功能
        public ActionResult ChannelIndex()
        {
            return View();
        }

        public ActionResult ChannelForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        public async Task<ActionResult> GetListJson(ChannelListParam param)
        {
            TData<List<ChannelEntity>> obj = await channelBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPageListJson(ChannelListParam param, Pagination pagination)
        {
            TData<List<ChannelEntity>> obj = await channelBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ChannelEntity> obj = await channelBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<ActionResult> SaveFormJson(ChannelEntity entity)
        {
            TData<string> obj = await channelBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await channelBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
