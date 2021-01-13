using Core;
using Infrastructure.Context;

namespace Infrastructure.UnitOfWorks
{
    public interface IInfrastructureUnitOfWork : IUnitOfWork
    {

    }

    public class InfrastructureUnitOfWork : UnitOfWork, IInfrastructureUnitOfWork
    {

        public InfrastructureUnitOfWork(InfrastructureDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
