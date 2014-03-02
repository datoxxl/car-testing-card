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
    
    public partial class TestingCardHistory
    {
        public TestingCardHistory()
        {
            this.TestingCardDetailHistories = new HashSet<TestingCardDetailHistory>();
        }
    
        public int TestingCardHistoryID { get; set; }
        public int TestingCardID { get; set; }
        public string Number { get; set; }
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
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string TestingCardNumber { get; set; }
    
        public virtual TestingCard TestingCard { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<TestingCardDetailHistory> TestingCardDetailHistories { get; set; }
    }
}
