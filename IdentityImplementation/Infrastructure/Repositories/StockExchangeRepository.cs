using Core;
using Infrastructure.BusinessObject;
using Infrastructure.Context;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface IStockExchangeRepository : IRepository<StockExchange, Guid, WorkerContext>
    {
        IEntity<Guid> AddStockExchange(StockExchangeInfo info);
    }

    public class StockExchangeRepository : Repository<StockExchange, Guid, WorkerContext>, IStockExchangeRepository
    {
        public StockExchangeRepository(WorkerContext dbContext)
            : base(dbContext)
        {

        }

        public IEntity<Guid> AddStockExchange(StockExchangeInfo info)
        {
            try
            {
                var exchangeData = Add(new StockExchange
                {
                    CompanyId = info.CompanyId,
                    LTP = info.LTP,
                    High = info.High,
                    Low = info.Low,
                    CloseUp = info.CloseUp,
                    YCP = info.YCP,
                    Change = info.Change,
                    Trade = info.Trade,
                    Value = info.Value,
                    Volume = info.Volume,
                    ExchangeAt = DateTime.Now
                });

                return new Entity<Guid>(exchangeData, nameof(exchangeData.Id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
