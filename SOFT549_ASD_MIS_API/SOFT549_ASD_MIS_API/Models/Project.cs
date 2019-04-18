using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOFT549_ASD_MIS_API.Models
{
    public partial class Project
    {
        public Project()
        {
            Activity = new HashSet<Activity>();
        }

        public int ProjectId { get; set; }
        public int ClientId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public DateTime PredictedLaunchDate { get; set; }
        public DateTime? ActualLaunchDate { get; set; }
        [Required]
        public DateTime PredictedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        [Required]
        public string PredictedCost { get; set; }
        public string ActualCost { get; set; }
        public int? Price { get; set; }

        public Client Client { get; set; }
        public ICollection<Activity> Activity { get; set; }
    }
}
