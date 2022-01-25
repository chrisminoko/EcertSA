using EcertApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcertApp.BLL.Contracts
{
    public interface ICategoryBll
    {
        PagedResult<Category> GetCategories(int page);
        Category GetCategory(int id);
        void DeleteCategory(int CategoryId);
        void CreateCategory(Category category);
    }
}
