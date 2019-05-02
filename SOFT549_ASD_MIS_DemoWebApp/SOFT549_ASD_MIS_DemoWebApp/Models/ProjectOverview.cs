using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class ProjectOverview
    {
        [DataMember(Name = "clientName")]
        public string ClientName { get; set; }
        
        public string ProjectName { get; set; }
        [DataMember(Name = "predictedLaunchDate")]
        public DateTime PredictedLaunchDate { get; set; }
        [DataMember(Name = "predictedCompletionDate")]
        public DateTime PredictedCompletionDate { get; set; }
        [DataMember(Name = "predictedCost")]
        public string PredictedCost { get; set; }
        [DataMember(Name = "actualCost")]
        public string ActualCost { get; set; }

        [DataMember(Name = "staffName")]
        public string StaffName { get; set; }
        [DataMember(Name = "staffContactDetails")]
        public string StaffContactDetails { get; set; }
    }
}
