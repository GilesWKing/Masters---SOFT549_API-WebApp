/*-----------------------------------------------------------------------------------------------------------*
 *-             Created by: ***** ******* ****                                                              -*
 *-                Made on: 08/04/2019 - Original API built.                                                -*
 *-                                                                                                         -*
 *-             Descripton: The Assignment model is the temporary store for the data from the Assignment    -* 
 *-                         (Tasks) Table.                                                                  -*
 *-----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace SOFT549_CW_API.Models
{
    public partial class Assignment
    {
        public short TaskId { get; set; }
        public short StaffId { get; set; }
        public string TaskName { get; set; }
        public short ActivityId { get; set; }
        public DateTime PredictedStartDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime PredictedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public int PredictedCost { get; set; }
        public int? ActualCost { get; set; }
        public byte TaskSequence { get; set; }

        public Activity Activity { get; set; }
        public Staff Staff { get; set; }
    }
}
