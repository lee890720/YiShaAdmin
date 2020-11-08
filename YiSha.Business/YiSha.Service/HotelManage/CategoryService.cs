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
    /// 日 期：2020-11-06 20:38
    /// 描 述：服务类
    /// </summary>
    public class CategoryService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<CategoryEntity>> GetList(CategoryListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<CategoryEntity>> GetPageList(CategoryListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<CategoryEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<CategoryEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(CategoryEntity entity)
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
            await this.BaseRepository().Delete<CategoryEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<CategoryEntity, bool>> ListFilter(CategoryListParam param)
        {
            var expression = LinqExtensions.True<CategoryEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
