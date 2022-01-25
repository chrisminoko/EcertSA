
using EcertApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcertApp.BLL.Contracts
{
    public interface IProductBll
    {
        PagedResult<Product> GetProducts(int page);
        Product GetProduct(int id);
        void DeleteProduct(int productId);
        void CreateProduct(Product product);
    }
}
