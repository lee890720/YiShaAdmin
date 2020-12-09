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
using YiSha.Enum.HotelManage;

namespace YiSha.Service.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 19:04
    /// 描 述：门店信息服务类
    /// </summary>
    public class BranchService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<BranchEntity>> GetList(BranchListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.OrderBy(p=>p.BranchSort).ToList();
        }

        public async Task<List<BranchEntity>> GetPageList(BranchListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<BranchEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<BranchEntity>(id);
        }
        public async Task<BranchEntity> GetEntity(string branchName)
        {
            return await this.BaseRepository().FindEntity<BranchEntity>(p=>p.BranchName==branchName);
        }

        public async Task<int> GetMaxSort()
        {
            object result = await this.BaseRepository().FindObject("SELECT MAX(BranchSort) FROM HtlBranch");
            int sort = result.ParseToInt();
            sort++;
            return sort;
        }

        /// <summary>
        /// 门店名称是否存在
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool ExistBranchName(BranchEntity entity)
        {
            var expression = LinqExtensions.True<BranchEntity>();
            expression = expression.And(t => t.BaseIsDelete == 0);
            if (entity.Id.IsNullOrZero())
            {
                expression = expression.And(t => t.BranchName == entity.BranchName);
            }
            else
            {
                expression = expression.And(t => t.BranchName == entity.BranchName && t.Id != entity.Id);
            }
            return this.BaseRepository().IQueryable(expression).Count() > 0 ? true : false;
        }

        /// <summary>
        /// 是否存在子分支
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistChildrenBranch(long id)
        {
            var expression = LinqExtensions.True<BranchEntity>();
            expression = expression.And(t => t.ParentId == id);
            return this.BaseRepository().IQueryable(expression).Count() > 0 ? true : false;
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(BranchEntity entity)
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
                    await db.Delete<BranchBelongEntity>(t => t.BranchId == entity.Id);
                    await entity.Modify();
                    await db.Update(entity);
                }
                // 渠道
                if (!string.IsNullOrEmpty(entity.ChannelIds))
                {
                    foreach (long channelId in TextHelper.SplitToArray<long>(entity.ChannelIds, ','))
                    {
                        BranchBelongEntity branchBelongEntity = new BranchBelongEntity();
                        branchBelongEntity.BranchId = entity.Id;
                        branchBelongEntity.BelongId = channelId;
                        branchBelongEntity.BelongType = BranchBelongTypeEnum.Channel.ParseToInt();
                        await branchBelongEntity.Create();
                        await db.Insert(branchBelongEntity);
                    }
                }
                //支付方式
                if (!string.IsNullOrEmpty(entity.PayIds))
                {
                    foreach (long PayId in TextHelper.SplitToArray<long>(entity.PayIds, ','))
                    {
                        BranchBelongEntity branchBelongEntity = new BranchBelongEntity();
                        branchBelongEntity.BranchId = entity.Id;
                        branchBelongEntity.BelongId = PayId;
                        branchBelongEntity.BelongType = BranchBelongTypeEnum.Pay.ParseToInt();
                        await branchBelongEntity.Create();
                        await db.Insert(branchBelongEntity);
                    }
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
            var db = await this.BaseRepository().BeginTrans();
            try
            {
                long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
                await db.Delete<BranchEntity>(idArr);
                await db.Delete<BranchBelongEntity>(t => idArr.Contains(t.BranchId.Value));
                await db.CommitTrans();
            }
            catch
            {
                await db.RollbackTrans();
                throw;
            }
        }
        #endregion

        #region 私有方法
        private Expression<Func<BranchEntity, bool>> ListFilter(BranchListParam param)
        {
            var expression = LinqExtensions.True<BranchEntity>();
            if (param != null)
            {
                if (!param.BranchName.IsEmpty())
                {
                    expression = expression.And(t => t.BranchName.Contains(param.BranchName));
                }
                if (param.BranchLevel>0)
                {
                    expression = expression.And(t => t.BranchLevel==param.BranchLevel);
                }
                if (param.Status > 0)
                {
                    expression = expression.And(t => t.Status == param.Status);
                }
            }
            return expression;
        }
        #endregion
    }
}
