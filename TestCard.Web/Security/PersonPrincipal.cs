using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TestCard.Domain;

namespace TestCard.Web.Security
{
    public class PersonPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public int PersonID { get; private set; }

        public PersonPrincipal(IIdentity identity, int personID)
        {
            Identity = identity;
            PersonID = personID;
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}