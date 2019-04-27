using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class Project
    {
        public Project()
        {
            Activity = new HashSet<Activity>();
        }

        [DataMember(Name = "projectId")]
        public int ProjectId { get; set; }
        [DataMember(Name = "clientId")]
        public int ClientId { get; set; }
        [DataMember(Name = "projectName")]
        public string ProjectName { get; set; }
        [DataMember(Name = "projectPredLaunchDate")]
        public DateTime PredictedLaunchDate { get; set; }
        [DataMember(Name = "projectActLaunchDate")]
        public DateTime? ActualLaunchDate { get; set; }
        [DataMember(Name = "projectPredCompDate")]
        public DateTime PredictedCompletionDate { get; set; }
        [DataMember(Name = "projectActCompDate")]
        public DateTime? ActualCompletionDate { get; set; }
        [DataMember(Name = "projectPredCost")]
        public string PredictedCost { get; set; }
        [DataMember(Name = "projectActCost")]
        public string ActualCost { get; set; }
        [DataMember(Name = "projectPrice")]
        public int? Price { get; set; }

        public Client Client { get; set; }
        public ICollection<Activity> Activity { get; set; }
    }
}
