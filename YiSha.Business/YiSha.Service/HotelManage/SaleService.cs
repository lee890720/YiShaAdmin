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
    /// 日 期：2020-07-04 16:47
    /// 描 述：房态订单服务类
    /// </summary>
    public class SaleService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<SaleEntity>> GetList(SaleListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<SaleEntity>> GetPageList(SaleListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<List<SaleEntity>> GetList2(SaleListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter2(param, strSql);
            var list = await this.BaseRepository().FindList<SaleEntity>(strSql.ToString(), filter.ToArray());
            return list.ToList();
        }

        public async Task<List<SaleEntity>> GetPageList2(SaleListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter2(param, strSql);
            var list = await this.BaseRepository().FindList<SaleEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<SaleEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<SaleEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(SaleEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                entity.Profit = entity.SalePrice - entity.PurchasePrice;
                entity.Profit = entity.SalePrice - entity.PurchasePrice;
                entity.Equity = entity.Profit - entity.Commission;
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                entity.Profit = entity.SalePrice - entity.PurchasePrice;
                entity.Profit = entity.SalePrice - entity.PurchasePrice;
                entity.Equity = entity.Profit - entity.Commission;
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
            await this.BaseRepository().Delete<SaleEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<SaleEntity, bool>> ListFilter(SaleListParam param)
        {
            var expression = LinqExtensions.True<SaleEntity>();
            if (param != null)
            {
            }
            return expression;
        }

        private List<DbParameter> ListFilter2(SaleListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.BaseIsDelete,
                                    a.BaseCreateTime,
                                    a.BaseCreatorId,
                                    a.BaseModifyTime,
                                    a.BaseModifierId,
                                    a.BaseVersion,
                                    a.CreateDate,
                                    a.SaleName,
                                    a.Phone,
                                    a.IDNumber,
                                    a.SalePrice,
                                    a.PurchasePrice,
                                    a.Profit,
                                    a.Equity,
                                    a.Commission,
                                    a.IsFinish,
                                    a.IsFinance,
                                    a.Sort,
                                    a.Remark,
                                    a.StewardId,
                                    a.ProductId,
                                    a.BranchId,
                                    b.BranchName,
                                    c.ProductName,
                                    d.RealName AS StewardName,
                                    g.RealName AS CreateName,
                                    h.RealName AS ModifierName
                            FROM    HtlSale a
                                    LEFT JOIN HtlBranch b ON a.BranchId = b.Id
                                    LEFT JOIN HtlProduct c ON a.ProductId=c.Id
                                    LEFT JOIN SysUser d ON a.StewardId=d.Id
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
                if (!string.IsNullOrEmpty(param.SaleName))
                {
                    strSql.Append(" AND a.SaleName like @SaleName");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@SaleName", "%" + param.SaleName + "%"));
                }
                if (!string.IsNullOrEmpty(param.Phone))
                {
                    strSql.Append(" AND a.Phone like @Phone");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@Phone", "%" + param.Phone + "%"));
                }
                if (!string.IsNullOrEmpty(param.IDNumber))
                {
                    strSql.Append(" AND a.IDNumber like @IDNumber");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@IDNumber", "%" + param.IDNumber + "%"));
                }
                if (!string.IsNullOrEmpty(param.ProductId.ToString()))
                {
                    strSql.Append(" AND a.ProductId = @ProductId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@ProductId", param.ProductId ));
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
                    strSql.Append(" AND a.CreateDate >= @StartDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@StartDate", param.StartDate));

                }
                if (!string.IsNullOrEmpty(param.EndDate.ParseToString()))
                {
                    strSql.Append(" AND a.CreateDate <= @EndDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@EndDate", param.EndDate));

                }
            }
            return parameter;
        }

        private Expression<Func<SaleEntity, bool>> ListFilter3(string param)
        {
            var expression = LinqExtensions.True<SaleEntity>();
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
