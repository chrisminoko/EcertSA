
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
    }
}