using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public interface IProductService : IDisposable
    {
    }

    public class ProductService : IProductService
    {
        public readonly IInfrastructureUnitOfWork _infrastructureUnitOfWork;

        public ProductService(IInfrastructureUnitOfWork infrastructureUnitOfWork)
        {
            _infrastructureUnitOfWork = infrastructureUnitOfWork;
        }

        public void Dispose()
        {
            _infrastructureUnitOfWork.Dispose();
        }
    }
}
