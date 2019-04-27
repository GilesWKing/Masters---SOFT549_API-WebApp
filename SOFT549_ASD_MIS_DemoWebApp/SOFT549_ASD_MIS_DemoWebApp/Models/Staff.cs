using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Activity = new HashSet<Activity>();
            Assignment = new HashSet<Assignment>();
        }

        [DataMember(Name = "staffId")]
        public int StaffId { get; set; }
        [DataMember(Name = "roleId")]
        public int RoleId { get; set; }
        [DataMember(Name = "staffName")]
        public string StaffName { get; set; }
        [DataMember(Name = "staffContactDetail")]
        public string ContactDetails { get; set; }
        [DataMember(Name = "staffOrganisation")]
        public string Organisation { get; set; }
        [DataMember(Name = "clientId")]
        public int? ClientId { get; set; }

        public Client Client { get; set; }
        public Role Role { get; set; }
        public ICollection<Activity> Activity { get; set; }
        public ICollection<Assignment> Assignment { get; set; }
    }
}
