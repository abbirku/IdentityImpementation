using Core;
using Infrastructure.Context;

namespace Infrastructure.UnitOfWorks
{
    public interface IWorkerUnitOfWork : IUnitOfWork
    {

    }

    public class WorkerUnitOfWork : UnitOfWork, IWorkerUnitOfWork
    {

        public WorkerUnitOfWork(InfrastructureDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
