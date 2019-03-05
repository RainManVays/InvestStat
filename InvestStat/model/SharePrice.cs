using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestStat.model
{
    class SharePrice
    {
        public int CompanyId { get; set; }
        public DateTime PriceTimeStamp { get; set; }
        public decimal Price { get; set; }
    }
}
