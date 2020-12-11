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
using YiSha.Model.Result.HotelManage;

namespace YiSha.Business.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-04 16:47
    /// 描 述：房态订单业务类
    /// </summary>
    public class SaleBLL
    {
        private SaleService saleService = new SaleService();

        #region 获取数据
        public async Task<TData<List<SaleEntity>>> GetList(SaleListParam param)
        {
            TData<List<SaleEntity>> obj = new TData<List<SaleEntity>>();
            obj.Data = await saleService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SaleEntity>>> GetPageList(SaleListParam param, Pagination pagination)
        {
            TData<List<SaleEntity>> obj = new TData<List<SaleEntity>>();
            obj.Data = await saleService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SaleEntity>>> GetListForDay(SaleListParam param)
        {
            TData<List<SaleEntity>> obj = new TData<List<SaleEntity>>();
            obj.Data = await saleService.GetListForDay(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SaleEntity>>> GetPageListForDay(SaleListParam param, Pagination pagination)
        {
            TData<List<SaleEntity>> obj = new TData<List<SaleEntity>>();
            obj.Data = await saleService.GetPageListForDay(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SaleBarData>>> GetListForDailyData(SaleListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate);
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate);
            var initDate = (DateTime)param.StartDate;
            List<SaleEntity> saleList = new List<SaleEntity>();
            TData<List<SaleBarData>> obj = new TData<List<SaleBarData>>();
            List<SaleBarData> templist = new List<SaleBarData>();
            for (var i = 0; i <= ((DateTime)param.EndDate - initDate).Days; i++)
            {
                param.StartDate = initDate.AddDays(i);
                saleList = await saleService.GetListForDay(param);
                if (saleList.Count > 0)
                {
                    SaleBarData temp = new SaleBarData
                    {
                        StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM-dd"),
                        Sale = saleList.Sum(x => x.SalePrice),
                        Equity = saleList.Sum(x => x.Equity),
                        Cost = saleList.Sum(x => x.Commission+x.PurchasePrice),
                        Total = saleList.Sum(x => x.Commission)
                    };
                    templist.Add(temp);
                }
                else
                {
                    SaleBarData temp = new SaleBarData
                    {
                        StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM-dd"),
                        Sale = 0,
                        Equity = 0,
                        Cost = 0,
                        Total= 0
                    };
                    templist.Add(temp);
                }
            }
            obj.Data = templist.ToList();
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SaleBarData>>> GetListForMonthData(SaleListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate).AddMonths(-12);
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate).AddMonths(-12);
            var initStartDate = (DateTime)param.StartDate;
            var initEndDate = (DateTime)param.EndDate;
            List<SaleEntity> saleList = new List<SaleEntity>();
            TData<List<SaleBarData>> obj = new TData<List<SaleBarData>>();
            List<SaleBarData> templist = new List<SaleBarData>();
            for (var i = 0; i <= 12; i++)
            {
                param.StartDate = initStartDate.AddMonths(i);
                param.EndDate = initEndDate.AddMonths(i);
                if (DateTime.Compare(DateTime.Now, (DateTime)param.EndDate) < 0)
                    param.EndDate = DateTime.Now;
                saleList = await saleService.GetList(param);
                if (saleList.Count > 0)
                {
                    SaleBarData temp = new SaleBarData
                    {
                        StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM"),
                        Sale = saleList.Sum(x => x.SalePrice),
                        Equity = saleList.Sum(x => x.Equity),
                        Cost = saleList.Sum(x => x.Commission + x.PurchasePrice),
                        Total = saleList.Sum(x => x.Commission)
                    };
                    templist.Add(temp);
                }
                else
                {
                    SaleBarData temp = new SaleBarData
                    {
                        StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM"),
                        Sale = 0,
                        Equity = 0,
                        Cost = 0,
                        Total = 0
                    };
                    templist.Add(temp);
                }
            }

            obj.Data = templist.ToList();
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<SaleBarData>> GetListForYearData(SaleListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate);
            if (DateTime.Compare(DateTime.Now, (DateTime)param.EndDate) < 0)
                param.EndDate = DateTime.Now;
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate).AddMonths(-11);
            List<SaleEntity> saleList = new List<SaleEntity>();
            TData<SaleBarData> obj = new TData<SaleBarData>();
            SaleBarData temp = new SaleBarData();
            int days = ((DateTime)param.EndDate - (DateTime)param.StartDate).Days;

            saleList = await saleService.GetList(param);
            if (saleList.Count > 0)
            {
                temp = new SaleBarData
                {
                    StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM") + "至" + ((DateTime)param.EndDate).ToString("yyyy-MM"),
                    Sale = saleList.Sum(x => x.SalePrice),
                    Equity = saleList.Sum(x => x.Equity),
                    Cost = saleList.Sum(x => x.Commission + x.PurchasePrice),
                    Total = saleList.Sum(x => x.Commission)
                };
            }
            else
            {
                temp = new SaleBarData
                {
                    StartDate = ((DateTime)param.StartDate).ToString("yyyy-MM") + "至" + ((DateTime)param.EndDate).ToString("yyyy-MM"),
                    Sale = 0,
                    Equity = 0,
                    Cost = 0,
                    Total = 0
                };
            }

            obj.Data = temp;
            obj.Total = 1;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SalePieData>>> GetListForPieMonthData(SaleListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate);
            if (DateTime.Compare(DateTime.Now, (DateTime)param.EndDate) < 0)
                param.EndDate = DateTime.Now;
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate);
            List<SaleEntity> saleList = new List<SaleEntity>();
            TData<List<SalePieData>> obj = new TData<List<SalePieData>>();
            SalePieData temp = new SalePieData();
            List<SalePieData> templist = new List<SalePieData>();

            saleList = await saleService.GetList(param);

            if (saleList.Count > 0)
            {
                templist = saleList.GroupBy(s => s.ProductName).Select(x => new SalePieData
                {
                    Product = x.Key,
                    Total = x.Count()
                }).ToList();
            }
            obj.Data = templist;
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SalePieData>>> GetListForPieYearData(SaleListParam param)
        {
            param.EndDate = DateTimeHelper.GetEndMonth((DateTime)param.StartDate);
            if (DateTime.Compare(DateTime.Now, (DateTime)param.EndDate) < 0)
                param.EndDate = DateTime.Now;
            param.StartDate = DateTimeHelper.GetStartMonth((DateTime)param.StartDate).AddMonths(-11);
            List<SaleEntity> saleList = new List<SaleEntity>();
            TData<List<SalePieData>> obj = new TData<List<SalePieData>>();
            SalePieData temp = new SalePieData();
            List<SalePieData> templist = new List<SalePieData>();

            saleList = await saleService.GetList(param);

            if (saleList.Count > 0)
            {
                templist = saleList.GroupBy(s => s.ProductName).Select(x => new SalePieData
                {
                    Product = x.Key,
                    Total = x.Count()
                }).ToList();
            }
            obj.Data = templist;
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<SaleEntity>> GetEntity(long id)
        {
            TData<SaleEntity> obj = new TData<SaleEntity>();
            obj.Data = await saleService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(SaleEntity entity)
        {
            TData<string> obj = new TData<string>();
            await saleService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> CheckForm(string ids)
        {
            TData obj = new TData();
            await saleService.CheckForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> RepealForm(string ids)
        {
            TData obj = new TData();
            await saleService.RepealForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await saleService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
