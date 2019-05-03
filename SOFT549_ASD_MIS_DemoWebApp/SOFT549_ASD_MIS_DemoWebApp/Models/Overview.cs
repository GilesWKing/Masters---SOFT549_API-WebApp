using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public class Overview
    {
        public Overview()
        {
        }

        public string ClientName { get; set; }

        public int ProjectId { get; set; }
        public DateTime PredictedLaunchDate { get; set; }
        public DateTime PredictedCompletionDate { get; set; }
        public string PredictedCost { get; set; }
        public string ActualCost { get; set; }

        public string StaffName { get; set; }
        public string ContactDetails { get; set; }
    }
}
