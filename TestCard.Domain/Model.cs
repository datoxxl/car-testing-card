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
    
    public partial class Model
    {
        public int ModelID { get; set; }
        public int BrandID { get; set; }
        public string Name { get; set; }
        public int CreatePersonID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool Visible { get; set; }
    
        public virtual Brand Brand { get; set; }
    }
}
