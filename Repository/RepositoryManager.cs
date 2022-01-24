using Contracts;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IProduct _productRepository;
        private ICategory _categoryRespository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IProduct Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_repositoryContext);
                return _productRepository;
            }
        }

        public ICategory Category
        {
            get
            {
                if (_categoryRespository == null)
                    _categoryRespository = new Categoryrepository(_repositoryContext);
                return _categoryRespository;
            }
        }
        public void Save() => _repositoryContext.SaveChanges();

    }
}
