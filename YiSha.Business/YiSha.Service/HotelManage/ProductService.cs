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
    /// 日 期：2020-11-06 20:39
    /// 描 述：服务类
    /// </summary>
    public class ProductService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ProductEntity>> GetList(ProductListParam param)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<ProductEntity>(strSql.ToString(), filter.ToArray());
            return list.ToList();
        }

        public async Task<List<ProductEntity>> GetPageList(ProductListParam param, Pagination pagination)
        {
            var strSql = new StringBuilder();
            List<DbParameter> filter = ListFilter(param, strSql);
            var list = await this.BaseRepository().FindList<ProductEntity>(strSql.ToString(), filter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<ProductEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ProductEntity>(id);
        }

        public async Task<ProductEntity> GetEntity(string productName)
        {
            return await this.BaseRepository().FindEntity<ProductEntity>(p => p.ProductName == productName);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ProductEntity entity)
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

            // 客户群
            if (!string.IsNullOrEmpty(entity.GroupIds))
            {
                foreach (long groupId in TextHelper.SplitToArray<long>(entity.GroupIds, ','))
                {
                    ProductBelongEntity productBelongEntity = new ProductBelongEntity();
                    productBelongEntity.ProductId = entity.Id;
                    productBelongEntity.BelongId = groupId;
                    await productBelongEntity.Create();
                    await this.BaseRepository().Insert(productBelongEntity);
                }
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<ProductEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private List<DbParameter> ListFilter(ProductListParam param, StringBuilder strSql)
        {
            strSql.Append(@"SELECT  a.Id,
                                    a.BaseIsDelete,
                                    a.BaseCreateTime,
                                    a.BaseCreatorId,
                                    a.BaseModifyTime,
                                    a.BaseModifierId,
                                    a.BaseVersion,
                                    a.ProductName,
                                    a.Specification,
                                    a.Unit,
                                    a.SalePrice,
                                    a.PurchasePrice,
                                    a.Sort,
                                    a.Remark,
                                    a.CategoryId,
                                    b.CategoryName
                            FROM    HtlProduct a
                                    LEFT JOIN HtlCategory b ON a.CategoryId = b.Id
                            WHERE   1 = 1");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.ProductName))
                {
                    strSql.Append(" AND a.ProductName like @ProductName");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@ProductName", "%" + param.ProductName + "%"));
                }
                if (!string.IsNullOrEmpty(param.CategoryId.ToString())&&(long)param.CategoryId>0)
                {                   
                    strSql.Append(" AND a.CategoryId = @CategoryId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@CategoryId", param.CategoryId));
                }
            }
            return parameter;
        }

        #endregion
    }
}
