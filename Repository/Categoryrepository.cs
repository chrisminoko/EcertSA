using Contracts;
using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Categoryrepository : RepositoryBase<Category>, ICategory
    {
        public Categoryrepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public IEnumerable<Category> GetAllCategories(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();



        public Category GetCategory(int companyId, bool trackChanges) =>
        FindByCondition(c => c.CategoryId.Equals(companyId), trackChanges)
        .SingleOrDefault();

        public void CreateCategory(Category category) => Create(category);
    }
}
