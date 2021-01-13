using Infrastructure.Entities;
using Core;
using Infrastructure.Context;
using System;

namespace Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Products, Guid, InfrastructureDbContext>
    {
    }

    public class ProductRepository : Repository<Products, Guid, InfrastructureDbContext>, IProductRepository
    {
        public ProductRepository(InfrastructureDbContext listContext)
            : base(listContext)
        { }
    }
}
