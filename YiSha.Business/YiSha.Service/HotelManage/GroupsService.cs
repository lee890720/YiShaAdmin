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
    /// 日 期：2020-11-07 12:27
    /// 描 述：服务类
    /// </summary>
    public class GroupsService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<GroupsEntity>> GetList(GroupsListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<GroupsEntity>(strSql.ToString(), filter.ToArray());
            return list.OrderByDescending(x=>x.Rank).ToList();
        }

        public async Task<List<GroupsEntity>> GetPageList(GroupsListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<GroupsEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.OrderByDescending(x => x.Rank).ToList();
        }

        public async Task<GroupsEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<GroupsEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(GroupsEntity entity)
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
            await this.BaseRepository().Delete<GroupsEntity>(idArr);
        }
        #endregion

        #region 私有方法
        //private Expression<Func<GroupsEntity, bool>> ListFilter(GroupsListParam param)
        //{
        //    var expression = LinqExtensions.True<GroupsEntity>();
        //    if (param != null)
        //    {
        //        if (!string.IsNullOrEmpty(param.GroupName))
        //        {
        //            expression = expression.And(t => t.GroupName == param.GroupName);
        //        }
        //    }
        //    return expression;
        //}

        private List<DbParameter> ListFilter(GroupsListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.BaseIsDelete,
                                    a.BaseCreateTime,
                                    a.BaseCreatorId,
                                    a.BaseModifyTime,
                                    a.BaseModifierId,
                                    a.BaseVersion,
                                    a.GroupName,
                                    a.Purpose,
                                    a.Contacts,
                                    a.Phone,
                                    a.Wechat,
                                    a.Area,
                                    a.Rank,
                                    a.Remark,
                                    a.CategoryId,
                                    b.CategoryName
                            FROM    HtlGroups a
                                    LEFT JOIN HtlCategory b ON a.CategoryId = b.Id
                            WHERE   1 = 1");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.GroupName))
                {
                    strSql.Append(" AND a.GroupName like @GroupName");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@GroupName", "%" + param.GroupName + "%"));
                }
                if (!string.IsNullOrEmpty(param.CategoryId.ToString()) && (long)param.CategoryId > 0)
                {
                    strSql.Append(" AND a.CategoryId = @CategoryId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@CategoryId", param.CategoryId));
                }
                if (!string.IsNullOrEmpty(param.Rank.ToString()) && (int)param.Rank > 0)
                {
                    strSql.Append(" AND a.Rank > @Rank");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@Rank", param.Rank));
                }
            }
            return parameter;
        }

        #endregion
    }
}
