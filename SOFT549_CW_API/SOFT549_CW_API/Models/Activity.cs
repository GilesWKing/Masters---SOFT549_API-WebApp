/*-----------------------------------------------------------------------------------------------------------*
 *-             Created by: ***** ******* ****                                                              -*
 *-                Made on: 08/04/2019 - Original API built.                                                -*
 *-                                                                                                         -*
 *-             Descripton: The Activity model is the temporary store for the data from the Activity Table. -*
 *-----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace SOFT549_CW_API.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Assignment = new HashSet<Assignment>();
        }

        public short ActivityId { get; set; }
        public short ProjectId { get; set; }
        public string ActivityName { get; set; }
        public short StaffId { get; set; }
        public DateTime PredictedStartDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime PredictedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public int PredictedCost { get; set; }
        public int? ActualCost { get; set; }
        public byte ActivitySequence { get; set; }

        public Project Project { get; set; }
        public Staff Staff { get; set; }
        public ICollection<Assignment> Assignment { get; set; }
    }
}
