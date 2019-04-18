using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOFT549_ASD_MIS_API.Models
{
    public partial class Assignment
    {
        public int TaskId { get; set; }
        public int StaffId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public int ActivityId { get; set; }
        [Required]
        public DateTime PredictedStartDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        [Required]
        public DateTime PredictedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        [Required]
        public int PredictedCost { get; set; }
        public int? ActualCost { get; set; }
        [Required]
        public short TaskSequence { get; set; }

        public Activity Activity { get; set; }
        public Staff Staff { get; set; }
    }
}
