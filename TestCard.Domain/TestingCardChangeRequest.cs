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
    
    public partial class TestingCardChangeRequest
    {
        public TestingCardChangeRequest()
        {
            this.TestingCardDetailChangeRequests = new HashSet<TestingCardDetailChangeRequest>();
            this.TestingCardFileChangeRequests = new HashSet<TestingCardFileChangeRequest>();
        }
    
        public int TestingCardChangeRequestID { get; set; }
        public Nullable<int> TestingCardID { get; set; }
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
        public Nullable<int> QualityManagerConfirmStatusID { get; set; }
        public Nullable<System.DateTime> QualityManagerConfirmDate { get; set; }
        public Nullable<int> QualityManagerPersonID { get; set; }
        public Nullable<int> AdministratorConfirmStatusID { get; set; }
        public Nullable<System.DateTime> AdministratorConfirmDate { get; set; }
        public Nullable<int> AdministratorPersonID { get; set; }
        public string TestingCardNumber { get; set; }
        public Nullable<bool> IsFirstTesting { get; set; }
        public Nullable<int> ReasonID { get; set; }
        public string ReasonDescription { get; set; }
        public string CarBrand { get; set; }
    
        public virtual ConfirmStatus QualityManagerConfirmStatus { get; set; }
        public virtual ConfirmStatus AdminConfirmStatus { get; set; }
        public virtual ICollection<TestingCardDetailChangeRequest> TestingCardDetailChangeRequests { get; set; }
        public virtual ICollection<TestingCardFileChangeRequest> TestingCardFileChangeRequests { get; set; }
        public virtual Person QualityManagerPerson { get; set; }
        public virtual Person ResponsiblePerson { get; set; }
        public virtual Person AdminPerson { get; set; }
        public virtual TestingCard TestingCard { get; set; }
        public virtual ChangeRequestReason ChangeRequestReason { get; set; }
    }
}
