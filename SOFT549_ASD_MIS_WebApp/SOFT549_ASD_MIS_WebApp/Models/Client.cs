﻿using System;
using System.Collections.Generic;

namespace SOFT549_ASD_MIS_WebApp.Models
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