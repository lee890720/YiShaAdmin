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
    /// 日 期：2020-09-24 13:11
    /// 描 述：业务类
    /// </summary>
    public class PricingBLL
    {
        private PricingService pricingService = new PricingService();

        #region 获取数据
        public async Task<TData<List<PricingEntity>>> GetList(PricingListParam param)
        {
            TData<List<PricingEntity>> obj = new TData<List<PricingEntity>>();
            obj.Data = await pricingService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PricingEntity>>> GetPageList(PricingListParam param, Pagination pagination)
        {
            TData<List<PricingEntity>> obj = new TData<List<PricingEntity>>();
            obj.Data = await pricingService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PricingEntity>> GetEntity(long id)
        {
            TData<PricingEntity> obj = new TData<PricingEntity>();
            obj.Data = await pricingService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PricingEntity entity)
        {
            TData<string> obj = new TData<string>();
            await pricingService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await pricingService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
