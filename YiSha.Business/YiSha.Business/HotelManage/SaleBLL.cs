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
    /// 日 期：2020-07-04 16:47
    /// 描 述：房态订单业务类
    /// </summary>
    public class SaleBLL
    {
        private SaleService SaleService = new SaleService();

        #region 获取数据
        public async Task<TData<List<SaleEntity>>> GetList(SaleListParam param)
        {
            TData<List<SaleEntity>> obj = new TData<List<SaleEntity>>();
            obj.Data = await SaleService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SaleEntity>>> GetPageList(SaleListParam param, Pagination pagination)
        {
            TData<List<SaleEntity>> obj = new TData<List<SaleEntity>>();
            obj.Data = await SaleService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SaleEntity>>> GetList2(SaleListParam param)
        {
            TData<List<SaleEntity>> obj = new TData<List<SaleEntity>>();
            obj.Data = await SaleService.GetList2(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SaleEntity>>> GetPageList2(SaleListParam param, Pagination pagination)
        {
            TData<List<SaleEntity>> obj = new TData<List<SaleEntity>>();
            obj.Data = await SaleService.GetPageList2(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<SaleEntity>> GetEntity(long id)
        {
            TData<SaleEntity> obj = new TData<SaleEntity>();
            obj.Data = await SaleService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(SaleEntity entity)
        {
            TData<string> obj = new TData<string>();
            await SaleService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> CheckForm(string ids)
        {
            TData obj = new TData();
            await SaleService.CheckForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> RepealForm(string ids)
        {
            TData obj = new TData();
            await SaleService.RepealForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await SaleService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
