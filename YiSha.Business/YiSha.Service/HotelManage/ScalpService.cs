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
using NPOI.SS.Formula.Functions;
using NPOI.HSSF.Record.Chart;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft;
using YiSha.Enum.HotelManage;

namespace YiSha.Service.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-09-16 22:37
    /// 描 述：服务类
    /// </summary>
    public class ScalpService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ScalpEntity>> GetList(ScalpListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ScalpEntity>> GetPageList(ScalpListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<List<ScalpEntity>> GetList2(ScalpListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter2(param, strSql);
            var list = await this.BaseRepository().FindList<ScalpEntity>(strSql.ToString(), filter.ToArray());
            return list.ToList();
        }

        public async Task<List<ScalpEntity>> GetPageList2(ScalpListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter2(param, strSql);
            var list = await this.BaseRepository().FindList<ScalpEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<ScalpEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ScalpEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ScalpEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                //entity.RealPrice = entity.TotalPrice -entity.Commission;
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
            var expression = ListFilter3(ids);
            var list = await this.BaseRepository().FindList(expression);
            foreach(var i in list)
            {
                i.IsFinance = 1;
                await this.BaseRepository().Update(i);
            }
        }

        public async Task RepealForm(string ids)
        {
            var expression = ListFilter3(ids);
            var list = await this.BaseRepository().FindList(expression);
            foreach (var i in list)
            {
                i.IsFinance = 0;
                await this.BaseRepository().Update(i);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<ScalpEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ScalpEntity, bool>> ListFilter(ScalpListParam param)
        {
            var expression = LinqExtensions.True<ScalpEntity>();
            if (param != null)
            {
            }
            return expression;
        }

        private List<DbParameter> ListFilter2(ScalpListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.BaseIsDelete,
                                    a.BaseCreateTime,
                                    a.BaseCreatorId,
                                    a.BaseModifyTime,
                                    a.BaseModifierId,
                                    a.BaseVersion,
                                    a.OrderName,
                                    a.OrderNumber,
                                    a.HouseNumber,
                                    a.StartDate,
                                    a.EndDate,
                                    a.Commission,
                                    a.TotalPrice,
                                    a.RealPrice,
                                    a.IsFinish,
                                    a.IsFinance,
                                    a.Remark,
                                    a.BranchId,
                                    a.ChannelId,
                                    b.BranchName,
                                    c.ChannelName,
                                    c.ChannelColor,
                                    g.RealName AS CreateName,
                                    h.RealName AS ModifierName
                            FROM    HtlScalp a
                                    LEFT JOIN HtlBranch b ON a.BranchId = b.Id
                                    LEFT JOIN HtlChannel c ON a.ChannelId=c.Id
                                    LEFT JOIN SysUser g ON a.BaseCreatorId=g.Id
                                    LEFT JOIN SysUser h ON a.BaseModifierId=h.Id
                            WHERE   1 = 1");
            var parameter = new List<DbParameter>();
            if(param!=null)
            {
                if (!string.IsNullOrEmpty(param.Id.ToString()))
                {
                    strSql.Append(" AND a.Id = @Id");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@Id", param.Id));
                }
                if (!string.IsNullOrEmpty(param.OrderName))
                {
                    strSql.Append(" AND a.OrderName like @OrderName");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@OrderName", "%" + param.OrderName + "%"));
                }
                if (!string.IsNullOrEmpty(param.OrderNumber))
                {
                    strSql.Append(" AND a.OrderNumber like @OrderNumber");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@OrderNumber", "%" + param.OrderNumber + "%"));
                }
                if (!string.IsNullOrEmpty(param.BranchId.ToString()))
                {
                    strSql.Append(" AND a.BranchId = @BranchId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@BranchId", param.BranchId));
                }
                if (!string.IsNullOrEmpty(param.IsFinish.ToString()))
                {
                    strSql.Append(" AND a.IsFinish = @IsFinish");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@IsFinish", param.IsFinish));
                }
                if (!string.IsNullOrEmpty(param.IsFinance.ToString()))
                {
                    strSql.Append(" AND a.IsFinance = @IsFinance");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@IsFinance", param.IsFinance));
                }
                if (!string.IsNullOrEmpty(param.StartDate.ParseToString()))
                {
                    strSql.Append(" AND a.EndDate > @StartDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@StartDate", param.StartDate));
                }
                if (!string.IsNullOrEmpty(param.EndDate.ParseToString()))
                {
                    //param.EndDate = (param.EndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59").ParseToDateTime();
                    strSql.Append(" AND a.StartDate < @EndDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@EndDate", param.EndDate));
                }
            }
            return parameter;
        }

        private Expression<Func<ScalpEntity, bool>> ListFilter3(string param)
        {
            var expression = LinqExtensions.True<ScalpEntity>();
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
