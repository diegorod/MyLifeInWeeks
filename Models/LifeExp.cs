using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLifeInWeeks.Models
{
    public class LifeExp
    {
        public string CountryOrRegion { get; set; }
        public decimal Overall { get; set; }
        public decimal? Female { get; set; }
        public decimal? Male { get; set; }
    }
}
