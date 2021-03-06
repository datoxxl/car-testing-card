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
    
    public partial class Person
    {
        public Person()
        {
            this.Companies = new HashSet<Company>();
            this.Companies1 = new HashSet<Company>();
            this.CompanyChangeRequests = new HashSet<CompanyChangeRequest>();
            this.CompanyChangeRequests1 = new HashSet<CompanyChangeRequest>();
            this.CompanyChangeRequests2 = new HashSet<CompanyChangeRequest>();
            this.CompanyChangeRequests3 = new HashSet<CompanyChangeRequest>();
            this.CompanyHistories = new HashSet<CompanyHistory>();
            this.CompanyHistories1 = new HashSet<CompanyHistory>();
            this.CompanyHistories2 = new HashSet<CompanyHistory>();
            this.CompanyHistories3 = new HashSet<CompanyHistory>();
            this.Person1 = new HashSet<Person>();
            this.PersonDays = new HashSet<PersonDay>();
            this.PersonHistories1 = new HashSet<PersonHistory>();
            this.PersonLeaves1 = new HashSet<PersonLeave>();
            this.PersonLeaveChangeRequests = new HashSet<PersonLeaveChangeRequest>();
            this.PersonLeaveChangeRequests1 = new HashSet<PersonLeaveChangeRequest>();
            this.PersonLeaveChangeRequests2 = new HashSet<PersonLeaveChangeRequest>();
            this.PersonLeaveChangeRequests3 = new HashSet<PersonLeaveChangeRequest>();
            this.PersonLeaveChangeRequests4 = new HashSet<PersonLeaveChangeRequest>();
            this.PersonLeaveHistories = new HashSet<PersonLeaveHistory>();
            this.PersonLeaveHistories1 = new HashSet<PersonLeaveHistory>();
            this.PersonSchedules = new HashSet<PersonSchedule>();
            this.ResponsiblePersonSchedules = new HashSet<PersonSchedule>();
            this.PersonScheduleHistories = new HashSet<PersonScheduleHistory>();
            this.TestingCardChangeRequests = new HashSet<TestingCardChangeRequest>();
            this.TestingCardChangeRequests1 = new HashSet<TestingCardChangeRequest>();
            this.TestingCardChangeRequests3 = new HashSet<TestingCardChangeRequest>();
            this.TestingCardHistories = new HashSet<TestingCardHistory>();
            this.AdminPersonChangeRequests = new HashSet<PersonChangeRequest>();
            this.PersonChangeRequests = new HashSet<PersonChangeRequest>();
            this.QualityManagerPersonChangeRequests = new HashSet<PersonChangeRequest>();
            this.ResponsiblePersonChangeRequests3 = new HashSet<PersonChangeRequest>();
            this.PersonHistories = new HashSet<PersonHistory>();
            this.PersonLeaves = new HashSet<PersonLeave>();
            this.PersonScheduleHistories1 = new HashSet<PersonScheduleHistory>();
            this.TestingCards = new HashSet<TestingCard>();
            this.PersonScheduleChangeRequests = new HashSet<PersonScheduleChangeRequest>();
            this.PersonScheduleChangeRequests1 = new HashSet<PersonScheduleChangeRequest>();
            this.PersonScheduleChangeRequests2 = new HashSet<PersonScheduleChangeRequest>();
            this.PersonScheduleChangeRequests3 = new HashSet<PersonScheduleChangeRequest>();
            this.PersonSessions = new HashSet<PersonSession>();
        }
    
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string IDNo { get; set; }
        public string SystemIDNo { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public int AccountTypeID { get; set; }
        public Nullable<int> FileID { get; set; }
        public string Password { get; set; }
        public Nullable<int> ResponsiblePersonID { get; set; }
        public System.DateTime EffectiveDate { get; set; }
    
        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Company> Companies1 { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<CompanyChangeRequest> CompanyChangeRequests { get; set; }
        public virtual ICollection<CompanyChangeRequest> CompanyChangeRequests1 { get; set; }
        public virtual ICollection<CompanyChangeRequest> CompanyChangeRequests2 { get; set; }
        public virtual ICollection<CompanyChangeRequest> CompanyChangeRequests3 { get; set; }
        public virtual ICollection<CompanyHistory> CompanyHistories { get; set; }
        public virtual ICollection<CompanyHistory> CompanyHistories1 { get; set; }
        public virtual ICollection<CompanyHistory> CompanyHistories2 { get; set; }
        public virtual ICollection<CompanyHistory> CompanyHistories3 { get; set; }
        public virtual File File { get; set; }
        public virtual ICollection<Person> Person1 { get; set; }
        public virtual Person Person2 { get; set; }
        public virtual ICollection<PersonDay> PersonDays { get; set; }
        public virtual ICollection<PersonHistory> PersonHistories1 { get; set; }
        public virtual ICollection<PersonLeave> PersonLeaves1 { get; set; }
        public virtual ICollection<PersonLeaveChangeRequest> PersonLeaveChangeRequests { get; set; }
        public virtual ICollection<PersonLeaveChangeRequest> PersonLeaveChangeRequests1 { get; set; }
        public virtual ICollection<PersonLeaveChangeRequest> PersonLeaveChangeRequests2 { get; set; }
        public virtual ICollection<PersonLeaveChangeRequest> PersonLeaveChangeRequests3 { get; set; }
        public virtual ICollection<PersonLeaveChangeRequest> PersonLeaveChangeRequests4 { get; set; }
        public virtual ICollection<PersonLeaveHistory> PersonLeaveHistories { get; set; }
        public virtual ICollection<PersonLeaveHistory> PersonLeaveHistories1 { get; set; }
        public virtual ICollection<PersonSchedule> PersonSchedules { get; set; }
        public virtual ICollection<PersonSchedule> ResponsiblePersonSchedules { get; set; }
        public virtual ICollection<PersonScheduleHistory> PersonScheduleHistories { get; set; }
        public virtual ICollection<TestingCardChangeRequest> TestingCardChangeRequests { get; set; }
        public virtual ICollection<TestingCardChangeRequest> TestingCardChangeRequests1 { get; set; }
        public virtual ICollection<TestingCardChangeRequest> TestingCardChangeRequests3 { get; set; }
        public virtual ICollection<TestingCardHistory> TestingCardHistories { get; set; }
        public virtual ICollection<PersonChangeRequest> AdminPersonChangeRequests { get; set; }
        public virtual ICollection<PersonChangeRequest> PersonChangeRequests { get; set; }
        public virtual ICollection<PersonChangeRequest> QualityManagerPersonChangeRequests { get; set; }
        public virtual ICollection<PersonChangeRequest> ResponsiblePersonChangeRequests3 { get; set; }
        public virtual ICollection<PersonHistory> PersonHistories { get; set; }
        public virtual ICollection<PersonLeave> PersonLeaves { get; set; }
        public virtual ICollection<PersonScheduleHistory> PersonScheduleHistories1 { get; set; }
        public virtual ICollection<TestingCard> TestingCards { get; set; }
        public virtual ICollection<PersonScheduleChangeRequest> PersonScheduleChangeRequests { get; set; }
        public virtual ICollection<PersonScheduleChangeRequest> PersonScheduleChangeRequests1 { get; set; }
        public virtual ICollection<PersonScheduleChangeRequest> PersonScheduleChangeRequests2 { get; set; }
        public virtual ICollection<PersonScheduleChangeRequest> PersonScheduleChangeRequests3 { get; set; }
        public virtual PersonStatistic PersonStatistic { get; set; }
        public virtual ICollection<PersonSession> PersonSessions { get; set; }
    }
}
