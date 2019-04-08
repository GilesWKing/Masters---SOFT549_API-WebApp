/*-----------------------------------------------------------------------------------------------------------*
 *-             Created by: ***** ******* ****                                                              -*
 *-                Made on: 08/04/2019 - Original API built.                                                -*
 *-                                                                                                         -*
 *-             Descripton: The Role model is the temporary store for the data from the Role table.         -* 
 *-----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace SOFT549_CW_API.Models
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
