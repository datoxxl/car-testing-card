﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestCardContext : DbContext
    {
        public TestCardContext()
            : base("name=TestCardContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyChangeRequest> CompanyChangeRequests { get; set; }
        public DbSet<CompanyHistory> CompanyHistories { get; set; }
        public DbSet<ConfirmStatus> ConfirmStatus1 { get; set; }
        public DbSet<ErrorCode> ErrorCodes { get; set; }
        public DbSet<PersonDay> PersonDays { get; set; }
        public DbSet<PersonHistory> PersonHistories { get; set; }
        public DbSet<PersonLeave> PersonLeaves { get; set; }
        public DbSet<PersonLeaveChangeRequest> PersonLeaveChangeRequests { get; set; }
        public DbSet<PersonLeaveHistory> PersonLeaveHistories { get; set; }
        public DbSet<PersonSchedule> PersonSchedules { get; set; }
        public DbSet<PersonScheduleHistory> PersonScheduleHistories { get; set; }
        public DbSet<TestingCard> TestingCards { get; set; }
        public DbSet<TestingCardChangeRequest> TestingCardChangeRequests { get; set; }
        public DbSet<TestingCardDetail> TestingCardDetails { get; set; }
        public DbSet<TestingCardDetailChangeRequest> TestingCardDetailChangeRequests { get; set; }
        public DbSet<TestingCardDetailHistory> TestingCardDetailHistories { get; set; }
        public DbSet<TestingCardFileChangeRequest> TestingCardFileChangeRequests { get; set; }
        public DbSet<TestingCardHistory> TestingCardHistories { get; set; }
        public DbSet<TestingStep> TestingSteps { get; set; }
        public DbSet<TestingSubStep> TestingSubSteps { get; set; }
        public DbSet<v_person> v_person { get; set; }
        public DbSet<v_PersonChangeRequest> v_PersonChangeRequest { get; set; }
        public DbSet<v_testing_cards> v_testing_cards { get; set; }
        public DbSet<v_TestingCard4Print> v_TestingCard4Print { get; set; }
        public DbSet<v_TestingCardDetail> v_TestingCardDetail { get; set; }
        public DbSet<v_TestingCardDetailChangeRequest> v_TestingCardDetailChangeRequest { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonChangeRequest> PersonChangeRequests { get; set; }
        public DbSet<PersonScheduleChangeRequest> PersonScheduleChangeRequests { get; set; }
        public DbSet<PersonScheduleChangeRequestDetail> PersonScheduleChangeRequestDetails { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<CodeType> CodeTypes { get; set; }
    }
}
