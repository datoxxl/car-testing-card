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
    
    public partial class TestingCardDetailChangeRequest
    {
        public int TestingCardChangeRequestID { get; set; }
        public Nullable<int> TestingCardID { get; set; }
        public int TestingSubStepID { get; set; }
        public bool IsValid { get; set; }
    
        public virtual TestingCardChangeRequest TestingCardChangeRequest { get; set; }
        public virtual TestingSubStep TestingSubStep { get; set; }
        public virtual TestingCard TestingCard { get; set; }
    }
}
