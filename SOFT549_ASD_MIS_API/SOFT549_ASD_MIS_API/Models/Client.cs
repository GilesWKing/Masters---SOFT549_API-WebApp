using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string ClientContact { get; set; }

        public ICollection<Project> Project { get; set; }
        public ICollection<Staff> Staff { get; set; }


        public int GetClientsID()
        {
            return ClientId;
        }

        public string GetClientsName()
        {
            return ClientName;
        }

        public string GetClientsContact()
        {
            return ClientContact;
        }

    }
}
