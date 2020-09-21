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
    /// 日 期：2020-07-03 16:31
    /// 描 述：支付方式服务类
    /// </summary>
    public class PayService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PayEntity>> GetList(PayListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<PayEntity>> GetPageList(PayListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<PayEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PayEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PayEntity entity)
        {
            var db = await this.BaseRepository().BeginTrans();
            try
            {
                if (entity.Id.IsNullOrZero())
                {
                    await entity.Create();
                    await db.Insert(entity);
                }
                else
                {
                    await this.BaseRepository().Update(entity);
                }
                await db.CommitTrans();
            }
            catch
            {
                await db.RollbackTrans();
                throw;
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<PayEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PayEntity, bool>> ListFilter(PayListParam param)
        {
            var expression = LinqExtensions.True<PayEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
