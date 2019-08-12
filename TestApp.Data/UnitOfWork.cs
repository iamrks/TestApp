using System;
using TestApp.BusinessLogic.Infrastructure.Interfaces;
using TestApp.Data.Repositories;

namespace TestApp.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _dbCtx;

        public UnitOfWork(ApplicationDbContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public IProductRepository _productRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbCtx);
                }

                return _productRepository;
            }
        }

        public ICategoryRepository _categoryRepository;

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_dbCtx);
                }

                return _categoryRepository;
            }
        }


        public void SaveChagnes()
        {
            _dbCtx.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbCtx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
