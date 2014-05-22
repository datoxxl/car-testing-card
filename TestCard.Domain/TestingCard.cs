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
    
    public partial class TestingCard
    {
        public TestingCard()
        {
            this.TestingCardDetails = new HashSet<TestingCardDetail>();
            this.TestingCardFileChangeRequests = new HashSet<TestingCardFileChangeRequest>();
            this.TestingCardHistories = new HashSet<TestingCardHistory>();
            this.Files = new HashSet<File>();
            this.TestingCardChangeRequests = new HashSet<TestingCardChangeRequest>();
            this.TestingCardDetailChangeRequests = new HashSet<TestingCardDetailChangeRequest>();
            this.TestingCardDetailHistories = new HashSet<TestingCardDetailHistory>();
        }
    
        public int TestingCardID { get; set; }
        public string Number { get; set; }
        public string TestingCardNumber { get; set; }
        public string VIN { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string CarSerialNo { get; set; }
        public Nullable<decimal> Odometer { get; set; }
        public string OwnerName { get; set; }
        public string OwnerIDNo { get; set; }
        public Nullable<bool> IsValid { get; set; }
        public string FirnishNumber { get; set; }
        public Nullable<System.DateTime> FirnishDate { get; set; }
        public string Comment { get; set; }
        public Nullable<int> ResponsiblePersonID { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<bool> IsFirstTesting { get; set; }
        public string CarBrand { get; set; }
    
        public virtual ICollection<TestingCardDetail> TestingCardDetails { get; set; }
        public virtual ICollection<TestingCardFileChangeRequest> TestingCardFileChangeRequests { get; set; }
        public virtual ICollection<TestingCardHistory> TestingCardHistories { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<TestingCardChangeRequest> TestingCardChangeRequests { get; set; }
        public virtual ICollection<TestingCardDetailChangeRequest> TestingCardDetailChangeRequests { get; set; }
        public virtual ICollection<TestingCardDetailHistory> TestingCardDetailHistories { get; set; }
    }
}
