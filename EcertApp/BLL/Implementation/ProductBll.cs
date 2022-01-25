
using EcertApp.BLL.Contracts;
using EcertApp.EcertApiHelper.Implementations;
using EcertApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EcertApp.BLL.Implementation
{
    public class ProductBll : IProductBll
    {
        private readonly IHttpLogic<Product> _http;
        private readonly IOptions<ApiUrl> _appSettings;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductBll(IHttpLogic<Product> http, IOptions<Models.ApiUrl> app, IWebHostEnvironment hostEnvironment)
        {
            _http = http;
            _appSettings = app;
            this._hostEnvironment = hostEnvironment;
        }
        public void CreateProduct(Product product)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            product.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                product.ImageFile.CopyTo(fileStream);
            }
            var baseurl = _appSettings.Value.BaseUrl + "Products";
            var serlizedProduct = new Product()
            {
                ProductId = product.ProductId,
                ProductCode = product.ProductCode,
                Price = product.Price,
                ImageName = product.ImageName,
                CategoryId = product.CategoryId,
                Description = product.Description,
                UserEmail = product.UserEmail,
                ProductName = product.ProductName,
                CategoryName = product.CategoryName

            };
            _http.PostCall(serlizedProduct, baseurl);
        }

        public void DeleteProduct(int productId)
        {
            var baseurl = _appSettings.Value.BaseUrl + $"Products/{productId}";
            _http.Delete(baseurl);
        }

        public Product GetProduct(int id)
        {
            var baseurl = _appSettings.Value.BaseUrl + "Products/";
            return _http.GetbyId(id, baseurl).Result;
        }

        public PagedResult<Product> GetProducts(int page)
        {
            var baseurl = _appSettings.Value.BaseUrl + "Products";
            var results = _http.Get(baseurl).Result.ToList();
            var pagedData = results.GetPaged(page, 10);
            PagedResult<Models.Product> pagedResult = new()
            {
                CurrentPage = pagedData.CurrentPage,
                PageCount = pagedData.PageCount,
                RowCount = pagedData.RowCount
            };

            foreach (var category in pagedData.Results)
            {
                pagedResult.Results.Add(category);
            }
            return pagedData;
        }
    }
}
