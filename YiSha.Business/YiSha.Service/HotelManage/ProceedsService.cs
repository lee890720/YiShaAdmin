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
    /// 日 期：2020-07-04 11:14
    /// 描 述：收款记录服务类
    /// </summary>
    public class ProceedsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ProceedsEntity>> GetList(ProceedsListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ProceedsEntity>> GetPageList(ProceedsListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<List<ProceedsEntity>> GetPageList2(ProceedsListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter2(param, strSql);
            var list = await this.BaseRepository().FindList<ProceedsEntity>(strSql.ToString(),filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<ProceedsEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ProceedsEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ProceedsEntity entity)
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
            await this.BaseRepository().Delete<ProceedsEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ProceedsEntity, bool>> ListFilter(ProceedsListParam param)
        {
            var expression = LinqExtensions.True<ProceedsEntity>();
            if (param != null)
            {
                if (param.OrderId>0)
                {
                    expression = expression.And(t => t.OrderId==param.OrderId);
                }
            }
            return expression;
        }

        private List<DbParameter> ListFilter2(ProceedsListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.BaseIsDelete,
                                    a.BaseCreateTime,
                                    a.BaseCreatorId,
                                    a.BaseModifyTime,
                                    a.BaseModifierId,
                                    a.BaseVersion,
                                    a.Amount,
                                    a.Remark,
                                    a.PayImage,
                                    a.PayId,
                                    a.BranchId,
                                    a.OrderId,
                                    b.BranchName,
                                    c.PayName,
                                    d.RealName
                            FROM    HtlProceeds a
                                    LEFT JOIN HtlBranch b ON a.BranchId = b.Id
                                    LEFT JOIN HtlPay c ON a.PayId=c.Id
                                    LEFT JOIN SysUser d ON a.BaseModifierId=d.Id
                            WHERE   1 = 1");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (param.OrderId>-1)
                {
                    strSql.Append(" AND a.OrderId = @OrderId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@OrderId",  param.OrderId ));
                }
            }
            return parameter;
        }
        #endregion
    }
}
