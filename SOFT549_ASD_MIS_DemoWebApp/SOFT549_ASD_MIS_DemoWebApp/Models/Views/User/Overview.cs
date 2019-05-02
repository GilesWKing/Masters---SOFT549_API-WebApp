using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SOFT549_ASD_MIS_DemoWebApp.Models.ViewModels.User
{
    public partial class Overview
    {
        public Overview()
        {
            ClientName = "N/A";
            PredictedLaunchDate = "N/A";
            PredictedCompletionDate = "N/A";
            PredictedCost = "N/A";
            ActualCost = "N/A";
            StaffName = "N/A";
            StaffContactDetails = "N/A";
        }

        public int? ProjectId { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }

        public string ClientName { get; set; }
        
        public string PredictedLaunchDate { get; set; }
        public string PredictedCompletionDate { get; set; }
        public string PredictedCost { get; set; }
        public string ActualCost { get; set; }
        
        public string StaffName { get; set; }
        public string StaffContactDetails { get; set; }
    }
}
