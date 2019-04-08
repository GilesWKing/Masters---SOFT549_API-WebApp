/*-----------------------------------------------------------------------------------------------------------*
 *-             Created by: ***** ******* ****                                                              -*
 *-                Made on: 08/04/2019 - Original API built.                                                -*
 *-                                                                                                         -*
 *-             Descripton: The Project model is the temporary store for the data from the Project table.   -* 
 *-----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace SOFT549_CW_API.Models
{
    public partial class Project
    {
        public Project()
        {
            Activity = new HashSet<Activity>();
        }

        public short ProjectId { get; set; }
        public short ClientId { get; set; }
        public string ProjectName { get; set; }
        public DateTime PredictedLaunchDate { get; set; }
        public DateTime? ActualLaunchDate { get; set; }
        public DateTime PredictedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public string PredictedCost { get; set; }
        public string ActualCost { get; set; }
        public int? Price { get; set; }

        public Client Client { get; set; }
        public ICollection<Activity> Activity { get; set; }
    }
}
