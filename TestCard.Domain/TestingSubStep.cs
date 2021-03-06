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
    
    public partial class TestingSubStep
    {
        public TestingSubStep()
        {
            this.TestingCardDetails = new HashSet<TestingCardDetail>();
            this.TestingCardDetailChangeRequests = new HashSet<TestingCardDetailChangeRequest>();
            this.TestingCardDetailHistories = new HashSet<TestingCardDetailHistory>();
        }
    
        public int TestingSubStepID { get; set; }
        public string TestingSubStepName { get; set; }
        public Nullable<int> TestingStepID { get; set; }
        public Nullable<int> OrderNumber { get; set; }
    
        public virtual ICollection<TestingCardDetail> TestingCardDetails { get; set; }
        public virtual ICollection<TestingCardDetailChangeRequest> TestingCardDetailChangeRequests { get; set; }
        public virtual TestingStep TestingStep { get; set; }
        public virtual ICollection<TestingCardDetailHistory> TestingCardDetailHistories { get; set; }
    }
}
