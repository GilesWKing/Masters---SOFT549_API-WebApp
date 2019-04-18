using System;
using System.Collections.Generic;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Assignment = new HashSet<Assignment>();
        }

        public int ActivityId { get; set; }
        public int ProjectId { get; set; }
        public string ActivityName { get; set; }
        public int StaffId { get; set; }
        public DateTime PredictedStartDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime PredictedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public int PredictedCost { get; set; }
        public int? ActualCost { get; set; }
        public short ActivitySequence { get; set; }

        public Project Project { get; set; }
        public Staff Staff { get; set; }
        public ICollection<Assignment> Assignment { get; set; }
    }
}
