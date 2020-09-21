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
    /// 日 期：2020-07-03 16:31
    /// 描 述：支付方式业务类
    /// </summary>
    public class PayBLL
    {
        private PayService PayService = new PayService();

        #region 获取数据
        public async Task<TData<List<PayEntity>>> GetList(PayListParam param)
        {
            TData<List<PayEntity>> obj = new TData<List<PayEntity>>();
            obj.Data = await PayService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PayEntity>>> GetPageList(PayListParam param, Pagination pagination)
        {
            TData<List<PayEntity>> obj = new TData<List<PayEntity>>();
            obj.Data = await PayService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PayEntity>> GetEntity(long id)
        {
            TData<PayEntity> obj = new TData<PayEntity>();
            obj.Data = await PayService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PayEntity entity)
        {
            TData<string> obj = new TData<string>();
            await PayService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await PayService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
