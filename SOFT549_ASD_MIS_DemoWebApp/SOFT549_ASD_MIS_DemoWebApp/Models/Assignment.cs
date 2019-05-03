using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class Assignment
    {
        [DataMember(Name = "taskId")]
        public int TaskId { get; set; }
        [DataMember(Name = "staffId")]
        public int StaffId { get; set; }
        [DataMember(Name = "taskName")]
        public string TaskName { get; set; }
        [DataMember(Name = "activityId")]
        public int ActivityId { get; set; }
        [DataMember(Name = "taskPredStartDate")]
        public DateTime PredictedStartDate { get; set; }
        [DataMember(Name = "taskActStartDate")]
        public DateTime? ActualStartDate { get; set; }
        [DataMember(Name = "taskPredCompDate")]
        public DateTime PredictedCompletionDate { get; set; }
        [DataMember(Name = "taskActCompDate")]
        public DateTime? ActualCompletionDate { get; set; }
        [DataMember(Name = "taskPredCost")]
        public int PredictedCost { get; set; }
        [DataMember(Name = "taskActCost")]
        public int? ActualCost { get; set; }
        [DataMember(Name = "taskSequence")]
        public short TaskSequence { get; set; }

        public Activity Activity { get; set; }
        public Staff Staff { get; set; }

    }
}
