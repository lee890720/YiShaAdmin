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
    /// 日 期：2020-07-03 18:39
    /// 描 述：预订渠道业务类
    /// </summary>
    public class ChannelBLL
    {
        private ChannelService channelService = new ChannelService();

        #region 获取数据
        public async Task<TData<List<ChannelEntity>>> GetList(ChannelListParam param)
        {
            TData<List<ChannelEntity>> obj = new TData<List<ChannelEntity>>();
            obj.Data = await channelService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ChannelEntity>>> GetPageList(ChannelListParam param, Pagination pagination)
        {
            TData<List<ChannelEntity>> obj = new TData<List<ChannelEntity>>();
            obj.Data = await channelService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ChannelEntity>> GetEntity(long id)
        {
            TData<ChannelEntity> obj = new TData<ChannelEntity>();
            obj.Data = await channelService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ChannelEntity entity)
        {
            TData<string> obj = new TData<string>();
            await channelService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await channelService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
