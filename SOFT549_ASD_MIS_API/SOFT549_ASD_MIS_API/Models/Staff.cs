using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOFT549_ASD_MIS_API.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Activity = new HashSet<Activity>();
            Assignment = new HashSet<Assignment>();
        }

        public int StaffId { get; set; }
        public int RoleId { get; set; }
        [Required]
        public string StaffName { get; set; }
        [Required]
        public string ContactDetails { get; set; }
        [Required]
        public string Organisation { get; set; }
        public int? ClientId { get; set; }

        public Client Client { get; set; }
        public Role Role { get; set; }
        public ICollection<Activity> Activity { get; set; }
        public ICollection<Assignment> Assignment { get; set; }
    }
}
