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
    
    public partial class Object
    {
        public Object()
        {
            this.ObjectPermissions = new HashSet<ObjectPermission>();
        }
    
        public int ObjectID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<ObjectPermission> ObjectPermissions { get; set; }
    }
}