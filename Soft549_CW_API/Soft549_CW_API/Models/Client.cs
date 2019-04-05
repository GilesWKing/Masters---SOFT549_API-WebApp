using System;
using System.Collections.Generic;

namespace Soft549_CW_API.Models
{
    public partial class Client
    {
        public Client()
        {
            Project = new HashSet<Project>();
        }

        public short ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientContact { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
