using System;

namespace InvestStat.model
{
    class CompanyModificators
    {
        public int CompanyId { get; set; }
        public DateTime ActualYear { get; set; }
        public decimal EarningsPerShare { get; set; }
        public decimal PriceToEarnings { get; set; }
        public decimal PriceToSales { get; set; }
        public decimal PriceToBookValue { get; set; }
        public decimal EnterpriseValue { get; set; }
        public decimal MergersAndAcquisitions { get; set; }
        public decimal Debt_EBITDA { get; set; }
        public decimal EV_EBITDA { get; set; }
        public decimal ReturnOnCommonEquity { get; set; }
        public decimal EBITDA { get; set; }
    }
}
