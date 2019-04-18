using System;
using System.Collections.Generic;

namespace SOFT549_ASD_MIS_API.Models
{
    public partial class Client
    {
        public Client()
        {
            Project = new HashSet<Project>();
            Staff = new HashSet<Staff>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientContact { get; set; }

        public ICollection<Project> Project { get; set; }
        public ICollection<Staff> Staff { get; set; }
    }
}
