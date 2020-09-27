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
    /// 日 期：2020-09-24 13:11
    /// 描 述：服务类
    /// </summary>
    public class PricingService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PricingEntity>> GetList(PricingListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.OrderBy(p=>p.Id).ToList();
        }

        public async Task<List<PricingEntity>> GetPageList(PricingListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.OrderBy(p => p.Id).ToList();
        }

        public async Task<PricingEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PricingEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PricingEntity entity)
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
            await this.BaseRepository().Delete<PricingEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PricingEntity, bool>> ListFilter(PricingListParam param)
        {
            var expression = LinqExtensions.True<PricingEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.BranchId.ToString()))
                {
                    expression = expression.And(t => t.BranchId == param.BranchId);
                }
            }
            return expression;
        }
        #endregion
    }
}
