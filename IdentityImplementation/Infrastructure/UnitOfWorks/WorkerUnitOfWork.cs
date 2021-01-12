using Core;
using Infrastructure.Context;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWorks
{
    public interface IWorkerUnitOfWork : IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; set; }
        IStockExchangeRepository StockExchangeRepository { get; set; }
    }

    public class WorkerUnitOfWork : UnitOfWork, IWorkerUnitOfWork
    {
        public ICompanyRepository CompanyRepository { get; set; }
        public IStockExchangeRepository StockExchangeRepository { get; set; }

        public WorkerUnitOfWork(WorkerContext dbContext, 
            ICompanyRepository companyRepository, 
            IStockExchangeRepository stockExchangeRepository)
            : base(dbContext)
        {
            CompanyRepository = companyRepository;
            StockExchangeRepository = stockExchangeRepository;
        }
    }
}
