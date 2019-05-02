using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOFT549_ASD_MIS_API.Models
{
    public partial class ProjectOverview
    {
        public string ClientName { get; set; }
        
        public DateTime PredictedLaunchDate { get; set; }
        public DateTime PredictedCompletionDate { get; set; }
        public string PredictedCost { get; set; }
        public string ActualCost { get; set; }

        public string StaffName { get; set; }
        public string StaffContactDetails { get; set; }

    }
}
