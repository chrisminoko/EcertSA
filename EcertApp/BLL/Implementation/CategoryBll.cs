
using EcertApp.BLL.Contracts;
using EcertApp.EcertApiHelper.Implementations;
using EcertApp.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcertApp.BLL.Implementation
{
    public class CategoryBll : ICategoryBll
    {
        private readonly IHttpLogic<Category> _http;
        private readonly IOptions<ApiUrl> _appSettings;
        public CategoryBll(IHttpLogic<Category> http, IOptions<ApiUrl> app)
        {
            _http = http;
            _appSettings = app;
        }

        public void CreateCategory(Category category)
        {
            var baseurl = _appSettings.Value.BaseUrl + "Categories";
             _http.PostCall(category, baseurl);
        }

        public void DeleteCategory(int CategoryId)
        {
            var baseurl = _appSettings.Value.BaseUrl + $"Categories/{CategoryId}";
            _http.Delete(baseurl);
        }

        public PagedResult<Category> GetCategories(int page)
        {
           var baseurl = _appSettings.Value.BaseUrl + "Categories";
           var results= _http.Get(baseurl).Result.ToList();
            var pagedData = results.GetPaged(page, 10);
            PagedResult<Models.Category> pagedResult = new()
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

        public Category GetCategory(int id)
        {
            var baseurl = _appSettings.Value.BaseUrl + "Categories/";
            return  _http.GetbyId(id, baseurl).Result;
        }
    }
}
