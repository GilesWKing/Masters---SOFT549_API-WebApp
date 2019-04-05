using System;
using System.Collections.Generic;

namespace Soft549_CW_API.Models
{
    public partial class Role
    {
        public Role()
        {
            Staff = new HashSet<Staff>();
        }

        public short RoleId { get; set; }
        public string RoleName { get; set; }
        public byte? CostPerHour { get; set; }

        public ICollection<Staff> Staff { get; set; }
    }
}
