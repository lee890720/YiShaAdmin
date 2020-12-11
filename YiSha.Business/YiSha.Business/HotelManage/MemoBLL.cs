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
    /// 日 期：2020-12-11 18:57
    /// 描 述：业务类
    /// </summary>
    public class MemoBLL
    {
        private MemoService memoService = new MemoService();

        #region 获取数据
        public async Task<TData<List<MemoEntity>>> GetList(MemoListParam param)
        {
            TData<List<MemoEntity>> obj = new TData<List<MemoEntity>>();
            obj.Data = await memoService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MemoEntity>>> GetPageList(MemoListParam param, Pagination pagination)
        {
            TData<List<MemoEntity>> obj = new TData<List<MemoEntity>>();
            obj.Data = await memoService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MemoEntity>> GetEntity(long id)
        {
            TData<MemoEntity> obj = new TData<MemoEntity>();
            obj.Data = await memoService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MemoEntity entity)
        {
            TData<string> obj = new TData<string>();
            await memoService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> CheckForm(string ids)
        {
            TData obj = new TData();
            await memoService.CheckForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> RepealForm(string ids)
        {
            TData obj = new TData();
            await memoService.RepealForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await memoService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
