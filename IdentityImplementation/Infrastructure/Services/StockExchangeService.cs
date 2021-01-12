using Infrastructure.Entities;
using Infrastructure.UnitOfWorks;
using System;
using System.Linq;

namespace Infrastructure.Services
{
    public interface IStockExchangeService
    {
        void UpdateStockExchangeInfo();
    }

    class StockExchangeService : IStockExchangeService
    {
        private readonly IParseFormWeb _parseForWeb;
        private readonly IWorkerUnitOfWork _workerUnitOfWork;

        public StockExchangeService(IParseFormWeb parseForWeb, IWorkerUnitOfWork workerUnitOfWork)
        {
            _parseForWeb = parseForWeb;
            _workerUnitOfWork = workerUnitOfWork;
        }

        public void UpdateStockExchangeInfo()
        {
            try
            {
                //Check market is open or not
                if (!_parseForWeb.IsMarketOpen())
                    return;

                var rawExchangeInfo = _parseForWeb.TraverseWeb();
                var parsedExchageInfos = _parseForWeb.ParseStockExchangeInfo(rawExchangeInfo);

                foreach (var info in parsedExchageInfos)
                {
                    var company = _workerUnitOfWork.CompanyRepository.AddCompany(info.TradingCode);
                    info.CompanyId = company.Id;

                    _workerUnitOfWork.StockExchangeRepository.AddStockExchange(info);
                }

                _workerUnitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
