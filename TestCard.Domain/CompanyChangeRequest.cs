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
    
    public partial class CompanyChangeRequest
    {
        public int CompanyChangeRequestID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> ContactPersonID { get; set; }
        public string Phone { get; set; }
        public string AccreditationScope { get; set; }
        public string AccreditationNumber { get; set; }
        public Nullable<System.DateTime> AccreditationExpireDate { get; set; }
        public int ResponsiblePersonID { get; set; }
        public System.DateTime EffectiveDate { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> QualityManagerConfirmStatusID { get; set; }
        public Nullable<System.DateTime> QualityManagerConfirmDate { get; set; }
        public Nullable<int> QualityManagerPersonID { get; set; }
        public Nullable<int> AdministratorConfirmStatusID { get; set; }
        public Nullable<System.DateTime> AdministratorConfirmDate { get; set; }
        public Nullable<int> AdministratorPersonID { get; set; }
        public string Address { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual ConfirmStatus ConfirmStatu { get; set; }
        public virtual ConfirmStatus ConfirmStatu1 { get; set; }
        public virtual Person Person { get; set; }
        public virtual Person Person1 { get; set; }
        public virtual Person Person2 { get; set; }
        public virtual Person Person3 { get; set; }
    }
}