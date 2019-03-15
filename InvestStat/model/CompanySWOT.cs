using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestStat.model
{
    [Table("CompanySWOT")]
  public class CompanySWOT
    {
        [Key]
        public int CompanyId { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public string Opportunities { get; set; }
        public string Threats { get; set; }
    }
}
