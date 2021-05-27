using System;
using System.Collections.Generic;

namespace Scheduler.Web.Models
{
    public class TrainingsView
    {
        public IEnumerable<Training> TodayTrainings { get; set; }
        public IEnumerable<Training> TomorrowTrainings { get; set; }
        public IEnumerable<Training> DayAfterTrainings  { get; set; }
        public IEnumerable<Training> DayAfter2Trainings { get; set; }
        public IEnumerable<Training> DayAfter3Trainings { get; set; }
        public IEnumerable<Training> DayAfter4Trainings { get; set; }
    }
}