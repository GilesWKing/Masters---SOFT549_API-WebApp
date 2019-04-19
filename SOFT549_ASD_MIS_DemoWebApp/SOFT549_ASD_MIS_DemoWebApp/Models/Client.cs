using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SOFT549_ASD_MIS_DemoWebApp.Models
{
    public partial class Client
    {
        public Client()
        {
            Project = new HashSet<Project>();
            Staff = new HashSet<Staff>();
        }

        [DataMember(Name = "clientId")]
        public int ClientId { get; set; }
        [DataMember(Name = "clientName")]
        public string ClientName { get; set; }
        [DataMember(Name = "clientContact")]
        public string ClientContact { get; set; }

        public ICollection<Project> Project { get; set; }
        public ICollection<Staff> Staff { get; set; }
    }
}
