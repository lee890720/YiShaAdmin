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
using YiSha.Model.Result.SystemManage;
using YiSha.Enum.HotelManage;
using YiSha.Model.Result;
using YiSha.Web.Code;

namespace YiSha.Business.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-03 19:04
    /// 描 述：门店信息业务类
    /// </summary>
    public class BranchBLL
    {
        private BranchService branchService = new BranchService();
        private BranchBelongService branchBelongService = new BranchBelongService();

        #region 获取数据
        public async Task<TData<List<BranchEntity>>> GetList(BranchListParam param)
        {
            TData<List<BranchEntity>> obj = new TData<List<BranchEntity>>();
            obj.Data = await branchService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<BranchEntity>>> GetPageList(BranchListParam param, Pagination pagination)
        {
            TData<List<BranchEntity>> obj = new TData<List<BranchEntity>>();
            obj.Data = await branchService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ZtreeInfo>>> GetZtreeBranchList(BranchListParam param)
        {
            var obj = new TData<List<ZtreeInfo>>();
            obj.Data = new List<ZtreeInfo>();
            List<BranchEntity> branchList = await branchService.GetList(param);
            foreach (BranchEntity branch in branchList)
            {
                obj.Data.Add(new ZtreeInfo
                {
                    id = branch.Id,
                    pId = branch.ParentId,
                    name = branch.BranchName
                });
            }
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<BranchEntity>> GetEntity(long id)
        {
            TData<BranchEntity> obj = new TData<BranchEntity>();
            obj.Data = await branchService.GetEntity(id);

            await GetBranchBelong(obj.Data);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }

        public async Task<TData<int>> GetMaxSort()
        {
            TData<int> obj = new TData<int>();
            obj.Data = await branchService.GetMaxSort();
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(BranchEntity entity)
        {
            TData<string> obj = new TData<string>();
            await branchService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            foreach (long id in TextHelper.SplitToArray<long>(ids, ','))
            {
                if (branchService.ExistChildrenBranch(id))
                {
                    obj.Message = "该分支下面有子分支！";
                    return obj;
                }
            }
            await branchService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取当前门店及下面所有的分支
        /// </summary>
        /// <param name="branchList"></param>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public async Task<List<long>> GetChildrenBranchIdList(List<BranchEntity> branchList, long branchId)
        {
            if (branchList == null)
            {
                branchList = await branchService.GetList(null);
            }
            List<long> branchIdList = new List<long>();
            branchIdList.Add(branchId);
            GetChildrenBranchIdList(branchList, branchId, branchIdList);
            return branchIdList;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获取该门店下面所有的分支
        /// </summary>
        /// <param name="branchList"></param>
        /// <param name="branchId"></param>
        /// <param name="branchIdList"></param>
        private void GetChildrenBranchIdList(List<BranchEntity> branchList, long branchId, List<long> branchIdList)
        {
            var children = branchList.Where(p => p.ParentId == branchId).Select(p => p.Id.Value).ToList();
            if (children.Count > 0)
            {
                branchIdList.AddRange(children);
                foreach (long id in children)
                {
                    GetChildrenBranchIdList(branchList, id, branchIdList);
                }
            }
        }

        /// <summary>
        /// 获取门店的渠道和支付方式
        /// </summary>
        /// <param name="branch"></param>
        private async Task GetBranchBelong(BranchEntity branch)
        {
            List<BranchBelongEntity> branchBelongList = await branchBelongService.GetList(new BranchBelongEntity { BranchId = branch.Id });

            List<BranchBelongEntity> channelBelongList = branchBelongList.Where(p => p.BelongType == BranchBelongTypeEnum.Channel.ParseToInt()).ToList();
            if (channelBelongList.Count > 0)
            {
                branch.ChannelIds = string.Join(",", channelBelongList.Select(p => p.BelongId).ToList());
            }

            List<BranchBelongEntity> PayBelongList = branchBelongList.Where(p => p.BelongType == BranchBelongTypeEnum.Pay.ParseToInt()).ToList();
            if (PayBelongList.Count > 0)
            {
                branch.PayIds = string.Join(",", PayBelongList.Select(p => p.BelongId).ToList());
            }
        }
        #endregion
    }
}
