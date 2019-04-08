/*-----------------------------------------------------------------------------------------------------------*
 *-             Created by: ***** ******* ****                                                              -*
 *-                Made on: 08/04/2019 - Original API built.                                                -*
 *-                                                                                                         -*
 *-             Descripton: The Client model is the temporary store for the data from the Client table.     -* 
 *-----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace SOFT549_CW_API.Models
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


        //----------------------------------------YYYYYYYYY-----------------------------------------------//

        // Creates public variables for functions in the Client Controller.

        public short GetClientsID()
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

        //-----------------------------------------^^^^^^^^^----------------------------------------------//

    }
}
