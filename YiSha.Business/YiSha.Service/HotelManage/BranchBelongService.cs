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
    /// 日 期：2020-07-03 19:18
    /// 描 述：门店属性服务类
    /// </summary>
    public class BranchBelongService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<BranchBelongEntity>> GetList(BranchBelongEntity entity)
        {
            var expression = LinqExtensions.True<BranchBelongEntity>();
            if (entity != null)
            {
                if (entity.BelongType != null)
                {
                    expression = expression.And(t => t.BelongType == entity.BelongType);
                }
                if (entity.BranchId != null)
                {
                    expression = expression.And(t => t.BranchId == entity.BranchId);
                }
            }
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<BranchBelongEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<BranchBelongEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(BranchBelongEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<BranchBelongEntity>(idArr);
        }
        #endregion
    }
}
