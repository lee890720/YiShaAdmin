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
    /// 日 期：2020-10-12 10:23
    /// 描 述：服务类
    /// </summary>
    public class PriceService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PriceEntity>> GetList(PriceListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<PriceEntity>> GetPageList(PriceListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<PriceEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PriceEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PriceEntity entity)
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
            await this.BaseRepository().Delete<PriceEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PriceEntity, bool>> ListFilter(PriceListParam param)
        {
            var expression = LinqExtensions.True<PriceEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
