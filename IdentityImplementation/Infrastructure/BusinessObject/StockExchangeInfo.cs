using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.BusinessObject
{
    public class StockExchangeInfo
    {
        public Guid CompanyId { get; set; }
        public string TradingCode { get; set; }
        public decimal LTP { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal CloseUp { get; set; }
        public decimal YCP { get; set; }
        public decimal Change { get; set; }
        public decimal Trade { get; set; }
        public decimal Value { get; set; }
        public decimal Volume { get; set; }
    }
}
