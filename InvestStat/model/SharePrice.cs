using System;

namespace InvestStat.model
{
    class SharePrice
    {
        public int CompanyId { get; set; }
        public DateTime PriceTimeStamp { get; set; }
        public decimal Price { get; set; }
    }
}
