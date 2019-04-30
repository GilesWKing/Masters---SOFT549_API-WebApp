using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class RequestForQuote
    {
        public RequestForQuote()
            {
            }

        [DataMember(Name = "quoteId")]
        public int QuoteId { get; set; }
        [DataMember(Name = "clientName")]
        public string ClientName { get; set; }
        [DataMember(Name = "clientPhone")]
        public string ClientPhone { get; set; }
        [DataMember(Name = "clientEmail")]
        public string ClientEmail { get; set; }
        [DataMember(Name = "clientRep")]
        public string ClientRep { get; set; }
        [DataMember(Name = "clientRepContact")]
        public string ClientRepContact { get; set; }
        [DataMember(Name = "projectName")]
        public string ProjectName { get; set; }
        [DataMember(Name = "projectManager")]
        public string ProjectManager { get; set; }
        [DataMember(Name = "predStartDate")]
        public DateTime PredStartDate { get; set; }
        [DataMember(Name = "predCompletionDate")]
        public DateTime PredCompletionDate { get; set; }
        [DataMember(Name = "projectDescription")]
        public string ProjectDescription { get; set; }
        [DataMember(Name = "predictedCost")]
        public string PredictedCost { get; set; }
    }
}
