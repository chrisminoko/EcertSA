using BLL.Contracts;
using Core.Entities;
using EcertApp.EcertApiHelper.Implementations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
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
        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
