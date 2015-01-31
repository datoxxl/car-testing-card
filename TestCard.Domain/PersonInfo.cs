using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCard.Domain
{
    public class PersonInfo
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNo { get; set; }
        public string Email { get; set; }
        public string AccountTypeName { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string SystemIDNo { get; set; }
        public Nullable<int> ResponsiblePersonID { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> FileID { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public AccountTypes AccountType { get; set; }
        public Dictionary<Objects, Permissions> Permissions { get; set; }
    }
}
