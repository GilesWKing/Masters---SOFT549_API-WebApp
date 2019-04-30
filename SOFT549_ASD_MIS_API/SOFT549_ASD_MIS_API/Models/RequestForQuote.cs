using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SOFT549_ASD_MIS_API.Models
{
    public partial class RequestForQuote
    {
        public int QuoteId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public string ClientRep { get; set; }
        public string ClientRepContact { get; set; }
        public string ProjectName { get; set; }
        public string ProjectManager { get; set; }
        public DateTime? PredStartDate { get; set; }
        public DateTime? PredCompletionDate { get; set; }
        public string ProjectDescription { get; set; }
        public string PredictedCost { get; set; }
    }
}
