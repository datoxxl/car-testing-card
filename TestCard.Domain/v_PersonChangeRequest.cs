//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestCard.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class v_PersonChangeRequest
    {
        public int PersonChangeRequestID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string IDNo { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string AccountTypeName { get; set; }
        public string OldFirstName { get; set; }
        public string OldLastName { get; set; }
        public string OldEmail { get; set; }
        public string OldMobile { get; set; }
        public string OldIDNo { get; set; }
        public Nullable<int> OldCompanyID { get; set; }
        public string OldCompanyName { get; set; }
        public string OldAccountTypeName { get; set; }
        public int AccountTypeID { get; set; }
        public Nullable<int> QualityManagerConfirmStatusID { get; set; }
        public Nullable<int> AdministratorConfirmStatusID { get; set; }
        public Nullable<int> QualityManagerPersonID { get; set; }
        public Nullable<int> AdministratorPersonID { get; set; }
    }
}
