using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Company : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string TradingCode { get; set; }
        public List<StockExchange> StockExchanges { get; set; }
    }
}
