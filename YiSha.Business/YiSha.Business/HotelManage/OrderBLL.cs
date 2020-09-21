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
    public class OrderBLL
    {
        private OrderService orderService = new OrderService();

        #region 获取数据
        public async Task<TData<List<OrderEntity>>> GetList(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetPageList(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetList2(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetList2(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetPageList2(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetPageList2(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<OrderEntity>> GetEntity(long id)
        {
            TData<OrderEntity> obj = new TData<OrderEntity>();
            obj.Data = await orderService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(OrderEntity entity)
        {
            TData<string> obj = new TData<string>();
            await orderService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> CheckForm(string ids)
        {
            TData obj = new TData();
            await orderService.CheckForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> RepealForm(string ids)
        {
            TData obj = new TData();
            await orderService.RepealForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await orderService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
