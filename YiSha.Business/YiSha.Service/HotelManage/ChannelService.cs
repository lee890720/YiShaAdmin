using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.HotelManage;
using YiSha.Model.Param.HotelManage;

namespace YiSha.Service.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 18:39
    /// 描 述：预订渠道服务类
    /// </summary>
    public class ChannelService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ChannelEntity>> GetList(ChannelListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ChannelEntity>> GetPageList(ChannelListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ChannelEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ChannelEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ChannelEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                await entity.Modify();
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<ChannelEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ChannelEntity, bool>> ListFilter(ChannelListParam param)
        {
            var expression = LinqExtensions.True<ChannelEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
