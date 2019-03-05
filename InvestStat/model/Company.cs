using System;
using System.ComponentModel.DataAnnotations;


namespace InvestStat.model
{
    class Company
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BaseDate { get; set; }
        public Industry Industry { get; set; }
    }
}
