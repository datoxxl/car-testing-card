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
    
    public partial class ConfirmStatus
    {
        public ConfirmStatus()
        {
            this.CompanyChangeRequests = new HashSet<CompanyChangeRequest>();
            this.CompanyChangeRequests1 = new HashSet<CompanyChangeRequest>();
            this.PersonLeaveChangeRequests = new HashSet<PersonLeaveChangeRequest>();
            this.PersonLeaveChangeRequests1 = new HashSet<PersonLeaveChangeRequest>();
            this.TestingCardChangeRequests = new HashSet<TestingCardChangeRequest>();
            this.TestingCardChangeRequests1 = new HashSet<TestingCardChangeRequest>();
            this.PersonChangeRequests = new HashSet<PersonChangeRequest>();
            this.PersonChangeRequests1 = new HashSet<PersonChangeRequest>();
            this.PersonScheduleChangeRequests = new HashSet<PersonScheduleChangeRequest>();
            this.PersonScheduleChangeRequests1 = new HashSet<PersonScheduleChangeRequest>();
        }
    
        public int ConfirmStatusID { get; set; }
        public string ConfirmStatusName { get; set; }
    
        public virtual ICollection<CompanyChangeRequest> CompanyChangeRequests { get; set; }
        public virtual ICollection<CompanyChangeRequest> CompanyChangeRequests1 { get; set; }
        public virtual ICollection<PersonLeaveChangeRequest> PersonLeaveChangeRequests { get; set; }
        public virtual ICollection<PersonLeaveChangeRequest> PersonLeaveChangeRequests1 { get; set; }
        public virtual ICollection<TestingCardChangeRequest> TestingCardChangeRequests { get; set; }
        public virtual ICollection<TestingCardChangeRequest> TestingCardChangeRequests1 { get; set; }
        public virtual ICollection<PersonChangeRequest> PersonChangeRequests { get; set; }
        public virtual ICollection<PersonChangeRequest> PersonChangeRequests1 { get; set; }
        public virtual ICollection<PersonScheduleChangeRequest> PersonScheduleChangeRequests { get; set; }
        public virtual ICollection<PersonScheduleChangeRequest> PersonScheduleChangeRequests1 { get; set; }
    }
}
