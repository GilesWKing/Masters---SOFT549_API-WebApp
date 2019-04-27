using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Assignment = new HashSet<Assignment>();
        }
        [DataMember(Name = "activityId")]
        public int ActivityId { get; set; }
        [DataMember(Name = "projectId")]
        public int ProjectId { get; set; }
        [DataMember(Name = "activityName")]
        public string ActivityName { get; set; }
        [DataMember(Name = "staffId")]
        public int StaffId { get; set; }
        [DataMember(Name = "activityPredStartDate")]
        public DateTime PredictedStartDate { get; set; }
        [DataMember(Name = "activityActStartDate")]
        public DateTime? ActualStartDate { get; set; }
        [DataMember(Name = "activityPredCompDate")]
        public DateTime PredictedCompletionDate { get; set; }
        [DataMember(Name = "activityActCompDate")]
        public DateTime? ActualCompletionDate { get; set; }
        [DataMember(Name = "activityPredCost")]
        public int PredictedCost { get; set; }
        [DataMember(Name = "activityActCost")]
        public int? ActualCost { get; set; }
        [DataMember(Name = "activitySequence")]
        public short ActivitySequence { get; set; }

        public Project Project { get; set; }
        public Staff Staff { get; set; }
        public ICollection<Assignment> Assignment { get; set; }
    }
}
