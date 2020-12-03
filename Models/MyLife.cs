using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyLifeInWeeks.Models
{
    public class MyLife
    {
        [Required]
        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-30);
        [Required]
        public string Gender { get; set; } = "Overall";
        [Required]
        public decimal LifeExp { get; set; } = 78;
        public int Age
        {
            get
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(BirthDate.ToString("yyyyMMdd"));
                return (now - dob) / 10000;
            }
        }
        public DateTime LifeExpDate => BirthDate.AddYears((int)Math.Round(LifeExp));
        public int LifeExpInWeeks => (int)Math.Round((LifeExpDate - BirthDate).TotalDays / 7);
        public int WeeksLeft => (int)Math.Round((LifeExpDate - DateTime.Now).TotalDays / 7);
        public decimal PercLeft => Math.Round(((decimal)WeeksLeft / (decimal)LifeExpInWeeks) * 100);
        public List<Week> GetLifeWeeks()
        {
            var result = new List<Week>();
            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < LifeExpInWeeks; i++)
            {
                var count = result.Count + 1;
                var week = new Week()
                {
                    Number = count,
                };

                if (result.Count == 0)
                {
                    week.StartDate = BirthDate.AddDays((double)(7 - BirthDate.DayOfWeek));
                }
                else
                {
                    var prevWeek = result[result.Count-1];
                    week.StartDate = prevWeek.StartDate.AddDays((double)(7 - prevWeek.StartDate.DayOfWeek));
                }

                week.EndDate = week.StartDate.AddDays(7);
                week.Lived = DateTime.Now <= week.EndDate;
                week.CurrentWeek = DateTime.Now >= week.StartDate && DateTime.Now <= week.EndDate;

                if (week.EndDate >= LifeExpDate)
                {
                    week.EndDate = LifeExpDate;
                    result.Add(week);
                    break;
                }
                result.Add(week);
            }
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            return result;
        }

        public bool GenderSelected => Gender != "Overall";
    }
}
