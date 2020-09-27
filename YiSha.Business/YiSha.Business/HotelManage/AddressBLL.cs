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
    /// 日 期：2020-09-24 13:10
    /// 描 述：业务类
    /// </summary>
    public class AddressBLL
    {
        private AddressService addressService = new AddressService();

        #region 获取数据
        public async Task<TData<List<AddressEntity>>> GetList(AddressListParam param)
        {
            TData<List<AddressEntity>> obj = new TData<List<AddressEntity>>();
            obj.Data = await addressService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<AddressEntity>>> GetPageList(AddressListParam param, Pagination pagination)
        {
            TData<List<AddressEntity>> obj = new TData<List<AddressEntity>>();
            obj.Data = await addressService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<AddressEntity>> GetEntity(long id)
        {
            TData<AddressEntity> obj = new TData<AddressEntity>();
            obj.Data = await addressService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(AddressEntity entity)
        {
            TData<string> obj = new TData<string>();
            await addressService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await addressService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
