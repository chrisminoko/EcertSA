
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
                CategoryId = 22,
                Description = product.Description,
                UserEmail = product.UserEmail,
                ProductName = product.ProductName,
                CategoryName = product.CategoryName

            };
            _http.PostCall(serlizedProduct, baseurl);
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public PagedResult<Product> GetProducts(int page)
        {
            throw new NotImplementedException();
        }
    }
}
