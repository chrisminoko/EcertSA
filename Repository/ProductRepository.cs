
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
    public class ProductRepository : RepositoryBase<Product>, IProduct
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(c => c.ProductName)
           .ToList();

        public Product GetProduct(int ProductId, bool trackChanges) =>
        FindByCondition(c => c.CategoryId.Equals(ProductId), trackChanges)
        .SingleOrDefault();

        public void CreateProduct(Product product) => Create(product);

        public void DeleteProduct(Product product) { Delete(product); }
    }
}