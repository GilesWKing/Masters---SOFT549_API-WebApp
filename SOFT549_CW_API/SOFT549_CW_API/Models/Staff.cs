/*-----------------------------------------------------------------------------------------------------------*
 *-             Created by: ***** ******* ****                                                              -*
 *-                Made on: 08/04/2019 - Original API built.                                                -*
 *-                                                                                                         -*
 *-             Descripton: The Staff model is the temporary store for the data from the Staff table.       -* 
 *-----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace SOFT549_CW_API.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Activity = new HashSet<Activity>();
            Assignment = new HashSet<Assignment>();
        }

        public short StaffId { get; set; }
        public short RoleId { get; set; }
        public string StaffName { get; set; }
        public string ContactDetails { get; set; }
        public string Organisation { get; set; }

        public Role Role { get; set; }
        public ICollection<Activity> Activity { get; set; }
        public ICollection<Assignment> Assignment { get; set; }
    }
}
