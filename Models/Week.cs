using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLifeInWeeks.Models
{
    public class Week
    {
        public int Number { get; set; }
        public bool Lived { get; set; }
        public bool PastExp { get; set; }
        public bool CurrentWeek { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
