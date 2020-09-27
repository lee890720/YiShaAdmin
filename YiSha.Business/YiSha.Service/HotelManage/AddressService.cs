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
    /// 日 期：2020-09-24 13:10
    /// 描 述：服务类
    /// </summary>
    public class AddressService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<AddressEntity>> GetList(AddressListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<AddressEntity>> GetPageList(AddressListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<AddressEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<AddressEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(AddressEntity entity)
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
            await this.BaseRepository().Delete<AddressEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<AddressEntity, bool>> ListFilter(AddressListParam param)
        {
            var expression = LinqExtensions.True<AddressEntity>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.BranchId.ToString()))
                {
                    expression = expression.And(t => t.BranchId == param.BranchId);
                }
            }
            return expression;
        }
        #endregion
    }
}
