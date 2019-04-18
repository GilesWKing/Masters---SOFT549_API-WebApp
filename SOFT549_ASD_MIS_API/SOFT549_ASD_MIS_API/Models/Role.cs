using System;
using System.Collections.Generic;

namespace SOFT549_ASD_MIS_API.Models
{
    public partial class Role
    {
        public Role()
        {
            Staff = new HashSet<Staff>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public short? CostPerHour { get; set; }

        public ICollection<Staff> Staff { get; set; }
    }
}
