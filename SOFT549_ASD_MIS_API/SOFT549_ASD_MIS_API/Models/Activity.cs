using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOFT549_ASD_MIS_API.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Assignment = new HashSet<Assignment>();
        }

        public int ActivityId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public string ActivityName { get; set; }
        public int StaffId { get; set; }
        [Required]
        public DateTime PredictedStartDate { get; set; }
        [Required]
        public DateTime? ActualStartDate { get; set; }
        [Required]
        public DateTime PredictedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public int PredictedCost { get; set; }
        public int? ActualCost { get; set; }
        [Required]
        public short ActivitySequence { get; set; }

        public Project Project { get; set; }
        public Staff Staff { get; set; }
        public ICollection<Assignment> Assignment { get; set; }
    }
}
