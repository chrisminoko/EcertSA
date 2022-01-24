using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface ICategory
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category GetCategory(int companyId, bool trackChanges);
    }
}
