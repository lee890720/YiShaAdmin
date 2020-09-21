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
    /// 日 期：2020-07-04 11:14
    /// 描 述：收款记录业务类
    /// </summary>
    public class ProceedsBLL
    {
        private ProceedsService proceedsService = new ProceedsService();

        #region 获取数据
        public async Task<TData<List<ProceedsEntity>>> GetList(ProceedsListParam param)
        {
            TData<List<ProceedsEntity>> obj = new TData<List<ProceedsEntity>>();
            obj.Data = await proceedsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ProceedsEntity>>> GetPageList(ProceedsListParam param, Pagination pagination)
        {
            TData<List<ProceedsEntity>> obj = new TData<List<ProceedsEntity>>();
            obj.Data = await proceedsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ProceedsEntity>>> GetPageList2(ProceedsListParam param, Pagination pagination)
        {
            TData<List<ProceedsEntity>> obj = new TData<List<ProceedsEntity>>();
            obj.Data = await proceedsService.GetPageList2(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ProceedsEntity>> GetEntity(long id)
        {
            TData<ProceedsEntity> obj = new TData<ProceedsEntity>();
            obj.Data = await proceedsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ProceedsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await proceedsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await proceedsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
