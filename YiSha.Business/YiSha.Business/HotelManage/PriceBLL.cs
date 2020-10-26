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
    /// 日 期：2020-10-12 10:23
    /// 描 述：业务类
    /// </summary>
    public class PriceBLL
    {
        private PriceService priceService = new PriceService();

        #region 获取数据
        public async Task<TData<List<PriceEntity>>> GetList(PriceListParam param)
        {
            TData<List<PriceEntity>> obj = new TData<List<PriceEntity>>();
            obj.Data = await priceService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PriceEntity>>> GetPageList(PriceListParam param, Pagination pagination)
        {
            TData<List<PriceEntity>> obj = new TData<List<PriceEntity>>();
            obj.Data = await priceService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PriceEntity>> GetEntity(long id)
        {
            TData<PriceEntity> obj = new TData<PriceEntity>();
            obj.Data = await priceService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PriceEntity entity)
        {
            TData<string> obj = new TData<string>();
            await priceService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await priceService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
