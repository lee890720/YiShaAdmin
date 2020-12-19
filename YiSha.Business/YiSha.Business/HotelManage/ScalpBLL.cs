using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.HotelManage;
using YiSha.Model.Param.HotelManage;
using YiSha.Service.HotelManage;

namespace YiSha.Business.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-16 22:37
    /// 描 述：业务类
    /// </summary>
    public class ScalpBLL
    {
        private ScalpService scalpService = new ScalpService();

        #region 获取数据
        public async Task<TData<List<ScalpEntity>>> GetList(ScalpListParam param)
        {
            TData<List<ScalpEntity>> obj = new TData<List<ScalpEntity>>();
            obj.Data = await scalpService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ScalpEntity>>> GetPageList(ScalpListParam param, Pagination pagination)
        {
            TData<List<ScalpEntity>> obj = new TData<List<ScalpEntity>>();
            obj.Data = await scalpService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ScalpEntity>>> GetListForDay(ScalpListParam param)
        {
            TData<List<ScalpEntity>> obj = new TData<List<ScalpEntity>>();
            obj.Data = await scalpService.GetListForDay(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ScalpEntity>>> GetPageListForDay(ScalpListParam param, Pagination pagination)
        {
            TData<List<ScalpEntity>> obj = new TData<List<ScalpEntity>>();
            obj.Data = await scalpService.GetPageListForDay(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ScalpEntity>> GetEntity(long id)
        {
            TData<ScalpEntity> obj = new TData<ScalpEntity>();
            obj.Data = await scalpService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ScalpEntity entity)
        {
            TData<string> obj = new TData<string>();
            await scalpService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> CheckForm(string ids)
        {
            TData obj = new TData();
            await scalpService.CheckForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> RepealForm(string ids)
        {
            TData obj = new TData();
            await scalpService.RepealForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await scalpService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
