using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class Role
    {
        public Role()
        {
            Staff = new HashSet<Staff>();
        }

        [DataMember(Name = "roleId")]
        public int RoleId { get; set; }
        [DataMember(Name = "roleName")]
        public string RoleName { get; set; }
        [DataMember(Name = "roleCost")]
        public short? CostPerHour { get; set; }

        public ICollection<Staff> Staff { get; set; }
    }
}
