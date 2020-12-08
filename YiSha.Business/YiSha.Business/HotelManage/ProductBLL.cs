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
using YiSha.Model.Param;

namespace YiSha.Business.HotelManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-11-06 20:39
    /// 描 述：业务类product
    /// </summary>
    public class ProductBLL
    {
        private ProductService productService = new ProductService();
        private ProductBelongService productBelongService = new ProductBelongService();

        #region 获取数据
        public async Task<TData<List<ProductEntity>>> GetList(ProductListParam param)
        {
            TData<List<ProductEntity>> obj = new TData<List<ProductEntity>>();
            obj.Data = await productService.GetList(param);
            foreach(var d in obj.Data)
            {
                await GetProductBelong(d);
            }
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ProductEntity>>> GetPageList(ProductListParam param, Pagination pagination)
        {
            TData<List<ProductEntity>> obj = new TData<List<ProductEntity>>();
            obj.Data = await productService.GetPageList(param, pagination);
            foreach (var d in obj.Data)
            {
                await GetProductBelong(d);
            } 
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ProductEntity>> GetEntity(long id)
        {
            TData<ProductEntity> obj = new TData<ProductEntity>();
            obj.Data = await productService.GetEntity(id);

            await GetProductBelong(obj.Data);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }

        public async Task<TData<List<ProductEntity>>> GetProductList(long? categoryId)
        {
            TData<List<ProductEntity>> obj = new TData<List<ProductEntity>>();
            List<ProductEntity> productList = await productService.GetList(new ProductListParam { CategoryId=categoryId});
            obj.Data = productList.OrderBy(x=>x.Sort).ToList();
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ProductEntity entity)
        {
            TData<string> obj = new TData<string>();
            await productService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await productService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> ImportProduct(ImportParam param, List<ProductEntity> list)
        {
            TData obj = new TData();
            if (list.Any())
            {
                foreach (ProductEntity entity in list)
                {
                    ProductEntity dbEntity = await productService.GetEntity(entity.ProductName);
                    if (dbEntity != null)
                    {
                        if (param.IsOverride == 1)
                        {
                            entity.Id = dbEntity.Id;
                            await productService.SaveForm(entity);
                        }
                        else
                        {
                            await productService.SaveForm(entity);
                        }
                    }
                    else
                    {
                        await productService.SaveForm(entity);
                    }
                }
                obj.Tag = 1;
            }
            else
            {
                obj.Message = " 未找到导入的数据";
            }
            return obj;
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 获取产品的客户群
        /// </summary>
        /// <param name="product"></param>
        private async Task GetProductBelong(ProductEntity product)
        {
            List<ProductBelongEntity> productBelongList = await productBelongService.GetList(new ProductBelongEntity { ProductId = product.Id });
            product.GroupIds = string.Join(",", productBelongList.Select(p => p.BelongId).ToList());
        }
        #endregion
    }
}
