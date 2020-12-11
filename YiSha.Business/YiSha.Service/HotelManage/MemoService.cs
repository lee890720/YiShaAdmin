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
    /// 日 期：2020-12-11 18:57
    /// 描 述：服务类
    /// </summary>
    public class MemoService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MemoEntity>> GetList(MemoListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<MemoEntity>(strSql.ToString(), filter.ToArray());
            return list.ToList();
        }

        public async Task<List<MemoEntity>> GetPageList(MemoListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<MemoEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<MemoEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MemoEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MemoEntity entity)
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

        public async Task CheckForm(string ids)
        {
            var expression = ListFilterForCheck(ids);
            var list = await this.BaseRepository().FindList(expression);
            foreach(var i in list)
            {
                i.IsFinish = 1;
                await this.BaseRepository().Update(i);
            }
        }

        public async Task RepealForm(string ids)
        {
            var expression = ListFilterForCheck(ids);
            var list = await this.BaseRepository().FindList(expression);
            foreach (var i in list)
            {
                i.IsFinish = 0;
                await this.BaseRepository().Update(i);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<MemoEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private List<DbParameter> ListFilter(MemoListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.BaseIsDelete,
                                    a.BaseCreateTime,
                                    a.BaseCreatorId,
                                    a.BaseModifyTime,
                                    a.BaseModifierId,
                                    a.BaseVersion,
                                    a.ExecuteDate,
                                    a.Memo,
                                    a.StewardId,
                                    a.IsFinish,
                                    a.BranchId,
                                    b.BranchName,
                                    c.RealName AS StewardName,
                                    d.RealName AS CreateName,
                                    e.RealName AS ModifierName
                            FROM    HtlMemo a
                                    LEFT JOIN HtlBranch b ON a.BranchId = b.Id
                                    LEFT JOIN SysUser c ON a.StewardId=c.Id
                                    LEFT JOIN SysUser d ON a.BaseCreatorId=d.Id
                                    LEFT JOIN SysUser e ON a.BaseModifierId=e.Id
                            WHERE   1 = 1");
            var parameter = new List<DbParameter>();
            if(param!=null)
            {
                if (!string.IsNullOrEmpty(param.Id.ToString()))
                {
                    strSql.Append(" AND a.Id = @Id");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@Id", param.Id));
                }
                if (!string.IsNullOrEmpty(param.Memo))
                {
                    strSql.Append(" AND a.Memo like @Memo");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@Memo", "%" + param.Memo + "%"));
                }
                if (!string.IsNullOrEmpty(param.BranchId.ToString()))
                {
                    strSql.Append(" AND a.BranchId = @BranchId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@BranchId", param.BranchId));
                }
                if (!string.IsNullOrEmpty(param.StewardId.ToString()))
                {
                    strSql.Append(" AND a.StewardId = @StewardId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@StewardId", param.StewardId));
                }
                if (!string.IsNullOrEmpty(param.IsFinish.ToString()))
                {
                    strSql.Append(" AND a.IsFinish = @IsFinish");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@IsFinish", param.IsFinish));
                }
                if (!string.IsNullOrEmpty(param.StartDate.ParseToString()))
                {
                    strSql.Append(" AND a.ExecuteDate >= @StartDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@StartDate", param.StartDate));
                }
                if (!string.IsNullOrEmpty(param.EndDate.ParseToString()))
                {
                    strSql.Append(" AND a.ExecuteDate <= @EndDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@EndDate", param.EndDate));
                }
                if (!string.IsNullOrEmpty(param.ExecuteDate.ParseToString()))
                {
                    strSql.Append(" AND a.ExecuteDate = @ExecuteDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@ExecuteDate", param.ExecuteDate));
                }
            }
            return parameter;
        }


        private Expression<Func<MemoEntity, bool>> ListFilterForCheck(string param)
        {
            var expression = LinqExtensions.True<MemoEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param))
                {
                    long[] IdArr = TextHelper.SplitToArray<long>(param, ',');
                    expression = expression.And(t => IdArr.Contains(t.Id.Value));
                }
            }
            return expression;
        }

        #endregion
    }
}
