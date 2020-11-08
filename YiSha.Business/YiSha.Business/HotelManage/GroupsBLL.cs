using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.HotelManage;
using YiSha.Model.Param.HotelManage;
using YiSha.Service.HotelManage;

namespace YiSha.Business.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-07 12:27
    /// 描 述：业务类
    /// </summary>
    public class GroupsBLL
    {
        private GroupsService groupsService = new GroupsService();

        #region 获取数据
        public async Task<TData<List<GroupsEntity>>> GetList(GroupsListParam param)
        {
            TData<List<GroupsEntity>> obj = new TData<List<GroupsEntity>>();
            obj.Data = await groupsService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<GroupsEntity>>> GetPageList(GroupsListParam param, Pagination pagination)
        {
            TData<List<GroupsEntity>> obj = new TData<List<GroupsEntity>>();
            obj.Data = await groupsService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<GroupsEntity>> GetEntity(long id)
        {
            TData<GroupsEntity> obj = new TData<GroupsEntity>();
            obj.Data = await groupsService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(GroupsEntity entity)
        {
            TData<string> obj = new TData<string>();
            await groupsService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await groupsService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
