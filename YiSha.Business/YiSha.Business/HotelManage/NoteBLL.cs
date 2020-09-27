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
    /// 日 期：2020-09-24 11:14
    /// 描 述：业务类
    /// </summary>
    public class NoteBLL
    {
        private NoteService noteService = new NoteService();

        #region 获取数据
        public async Task<TData<List<NoteEntity>>> GetList(NoteListParam param)
        {
            TData<List<NoteEntity>> obj = new TData<List<NoteEntity>>();
            obj.Data = await noteService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<NoteEntity>>> GetPageList(NoteListParam param, Pagination pagination)
        {
            TData<List<NoteEntity>> obj = new TData<List<NoteEntity>>();
            obj.Data = await noteService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<NoteEntity>> GetEntity(long id)
        {
            TData<NoteEntity> obj = new TData<NoteEntity>();
            obj.Data = await noteService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(NoteEntity entity)
        {
            TData<string> obj = new TData<string>();
            await noteService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await noteService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
