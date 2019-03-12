using System;

namespace InvestStat.model
{
    class CompanyFinancialInformation
    {
        public int CompanyId { get; set; }
        public DateTime ActualYear { get; set; }
        public decimal Assets { get; set; }
        public decimal Liabilities { get; set; }
        public decimal Earnings { get; set; }
        public decimal Price { get; set; }
        public decimal Sales { get; set; }
        public decimal BookValue { get; set; }
        public decimal EnterpriseValue { get; set; }
    }
}
