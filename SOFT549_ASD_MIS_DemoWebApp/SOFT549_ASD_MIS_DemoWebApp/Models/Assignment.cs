using System;
using System.Collections.Generic;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class Assignment
    {
        public int TaskId { get; set; }
        public int StaffId { get; set; }
        public string TaskName { get; set; }
        public int ActivityId { get; set; }
        public DateTime PredictedStartDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime PredictedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public int PredictedCost { get; set; }
        public int? ActualCost { get; set; }
        public short TaskSequence { get; set; }

        public Activity Activity { get; set; }
        public Staff Staff { get; set; }
    }
}
