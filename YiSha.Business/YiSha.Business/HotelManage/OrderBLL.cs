using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.HotelManage;
using YiSha.Model.Param.HotelManage;
using YiSha.Model.Result.HotelManage;
using YiSha.Service.HotelManage;
using Microsoft.AspNetCore.Mvc;

namespace YiSha.Business.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-04 16:47
    /// 描 述：房态订单业务类
    /// </summary>
    public class OrderBLL
    {
        private BranchService branchService = new BranchService();
        private OrderService orderService = new OrderService();

        #region 获取数据
        public async Task<TData<List<OrderEntity>>> GetList(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetListForCal(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetListForCal(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetPageList(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetPageListForDel(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetPageListForDel(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetListForDay(OrderListParam param)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetListForDay(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderEntity>>> GetPageListForDay(OrderListParam param, Pagination pagination)
        {
            TData<List<OrderEntity>> obj = new TData<List<OrderEntity>>();
            obj.Data = await orderService.GetPageListForDay(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderBarData>>> GetListForDailyData(OrderListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate);
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate);
            var initDate = (DateTime)param.StartDate;
            BranchEntity branchCount = await branchService.GetEntity((long)param.BranchId);
            List<OrderEntity> orderList = new List<OrderEntity>();
            TData<List<OrderBarData>> obj = new TData<List<OrderBarData>>();
            List<OrderBarData> templist = new List<OrderBarData>();
            for (var i = 0; i <=((DateTime)param.EndDate- initDate).Days; i++)
            {
                param.StartDate = initDate.AddDays(i);
                orderList = await orderService.GetListForDay(param);
                if (orderList.Count > 0)
                {
                    OrderBarData temp = new OrderBarData
                    {
                        //StartDate = i==0?((DateTime)param.StartDate).ToString("yyyy-MM-dd"): ((DateTime)param.StartDate).ToString("MM-dd"),
                        StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM-dd"),
                        HouseAmount = orderList.Sum(x => x.UnitPrice),
                        HouseTotal = branchCount.HouseCount,
                        HouseCount = orderList.Count,
                        Rate = (double)orderList.Count / (double)branchCount.HouseCount,
                        Average = (decimal)orderList.Sum(x => x.UnitPrice) / (decimal)orderList.Count,
                        ValidAverage = (decimal)orderList.Sum(x => x.UnitPrice) / (decimal)branchCount.HouseCount,
                    };
                    templist.Add(temp);
                }
                else
                {
                    OrderBarData temp = new OrderBarData
                    {
                        StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM-dd"),
                        HouseAmount = 0,
                        HouseTotal = branchCount.HouseCount,
                        HouseCount = 0,
                        Rate = 0,
                        Average = 0,
                        ValidAverage = 0,
                    };
                    templist.Add(temp);
                }
            }
            obj.Data = templist.ToList();
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderBarData>>> GetListForMonthData(OrderListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate).AddMonths(-12);
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate).AddMonths(-12);
            var initStartDate = (DateTime)param.StartDate;
            var initEndDate = (DateTime)param.EndDate;
            BranchEntity branchCount = await branchService.GetEntity((long)param.BranchId);
            List<OrderEntity> orderList = new List<OrderEntity>();
            TData<List<OrderBarData>> obj = new TData<List<OrderBarData>>();
            List<OrderBarData> templist = new List<OrderBarData>();
            for (var i = 0; i <= 12; i++)
            {
                param.StartDate = initStartDate.AddMonths(i);
                param.EndDate= initEndDate.AddMonths(i);
                if (DateTime.Compare(DateTime.Now, (DateTime)param.EndDate) < 0)
                    param.EndDate =DateTime.Now;
                orderList = await orderService.GetList(param);
                if (orderList.Count > 0)
                {
                    OrderBarData temp = new OrderBarData
                    {
                        StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM"),
                        HouseAmount = orderList.Sum(x => x.TotalPrice),
                        HouseTotal = branchCount.HouseCount*DateTimeHelper.GetDaysInMonth((DateTime)param.StartDate),
                        HouseCount = orderList.Sum(x => x.HouseCount),
                        Rate = (double)orderList.Sum(x => x.HouseCount) / (double)(branchCount.HouseCount * DateTimeHelper.GetDaysInMonth((DateTime)param.StartDate)),
                        Average = (decimal)orderList.Sum(x => x.TotalPrice) / (decimal)(orderList.Sum(x => x.HouseCount)),
                        ValidAverage = (decimal)orderList.Sum(x => x.TotalPrice) / (decimal)(branchCount.HouseCount * DateTimeHelper.GetDaysInMonth((DateTime)param.StartDate)),
                    };
                    templist.Add(temp);
                }
                else
                {
                    OrderBarData temp = new OrderBarData
                    {
                        StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM"),
                        HouseAmount = 0,
                        HouseTotal = branchCount.HouseCount * DateTimeHelper.GetDaysInMonth((DateTime)param.StartDate),
                        HouseCount = 0,
                        Rate = 0,
                        Average = 0,
                        ValidAverage = 0,
                    };
                    templist.Add(temp);
                }
            }

            obj.Data = templist.ToList();
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<OrderBarData>> GetListForYearData(OrderListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate);
            if (DateTime.Compare(DateTime.Now, (DateTime)param.EndDate) < 0)
                param.EndDate = DateTime.Now;
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate).AddMonths(-11); 
            BranchEntity branchCount = await branchService.GetEntity((long)param.BranchId);
            List<OrderEntity> orderList = new List<OrderEntity>();
            TData<OrderBarData> obj = new TData<OrderBarData>();
            OrderBarData temp = new OrderBarData();
            int days = ((DateTime)param.EndDate-(DateTime)param.StartDate).Days;

            orderList = await orderService.GetList(param);
            if (orderList.Count > 0)
            {
                temp = new OrderBarData
                {
                    StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM") + "至" + ((DateTime)param.EndDate).ToString("yyyy-MM"),
                    HouseAmount = orderList.Sum(x => x.TotalPrice),
                    HouseTotal = branchCount.HouseCount * days,
                    HouseCount = orderList.Sum(x => x.HouseCount),
                    Rate = (double)orderList.Sum(x => x.HouseCount) / (double)(branchCount.HouseCount * days),
                    Average = (decimal)orderList.Sum(x => x.TotalPrice) / (decimal)(orderList.Sum(x => x.HouseCount)),
                    ValidAverage = (decimal)orderList.Sum(x => x.TotalPrice) / (decimal)(branchCount.HouseCount * days),
                };
            }
            else
            {
                temp = new OrderBarData
                {
                    StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM") + "至" + ((DateTime)param.EndDate).ToString("yyyy-MM"),
                    HouseAmount = 0,
                    HouseTotal = branchCount.HouseCount * days,
                    HouseCount = 0,
                    Rate = 0,
                    Average = 0,
                    ValidAverage = 0,
                };
            }

            obj.Data = temp;
            obj.Total = 1;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderPieData>>> GetListForPieMonthData(OrderListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate);
            if (DateTime.Compare(DateTime.Now, (DateTime)param.EndDate) < 0)
                param.EndDate = DateTime.Now;
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate);
            BranchEntity branchCount = await branchService.GetEntity((long)param.BranchId);
            List<OrderEntity> orderList = new List<OrderEntity>();
            TData<List<OrderPieData>> obj = new TData<List<OrderPieData>>();
            OrderPieData temp = new OrderPieData();
            List<OrderPieData> templist = new List<OrderPieData>();

            orderList = await orderService.GetList(param);

            if (orderList.Count > 0)
            {
                templist = orderList.GroupBy(s => s.ChannelName).Select(x=>new OrderPieData { 
                    Channel=x.Key,
                    CTotal=x.Sum(s=>s.HouseCount),
                    ATotal=x.Sum(s=>s.TotalPrice)
                }).ToList();
            }
            obj.Data = templist;
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<OrderPieData>>> GetListForPieYearData(OrderListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate);
            if (DateTime.Compare(DateTime.Now, (DateTime)param.EndDate) < 0)
                param.EndDate = DateTime.Now;
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate).AddMonths(-11);
            BranchEntity branchCount = await branchService.GetEntity((long)param.BranchId);
            List<OrderEntity> orderList = new List<OrderEntity>();
            TData<List<OrderPieData>> obj = new TData<List<OrderPieData>>();
            OrderPieData temp = new OrderPieData();
            List<OrderPieData> templist = new List<OrderPieData>();

            orderList = await orderService.GetList(param);

            if (orderList.Count > 0)
            {
                templist = orderList.GroupBy(s => s.ChannelName).Select(x => new OrderPieData
                {
                    Channel = x.Key,
                    CTotal = x.Sum(s => s.HouseCount),
                    ATotal = x.Sum(s => s.TotalPrice)
                }).ToList();
            }
            obj.Data = templist;
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<OrderEntity>> GetEntity(long id)
        {
            TData<OrderEntity> obj = new TData<OrderEntity>();
            obj.Data = await orderService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(OrderEntity entity)
        {
            TData<string> obj = new TData<string>();
            await orderService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> CheckForm(string ids)
        {
            TData obj = new TData();
            await orderService.CheckForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> RepealForm(string ids)
        {
            TData obj = new TData();
            await orderService.RepealForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await orderService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
