using System;
using System.ComponentModel.DataAnnotations;


namespace InvestStat.model
{
   public class Company
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string BaseDate { get; set; }
        public Industry Industry { get; set; }
    }
}
 