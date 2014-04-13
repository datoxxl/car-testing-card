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
    
    public partial class File
    {
        public File()
        {
            this.PersonHistories = new HashSet<PersonHistory>();
            this.TestingCardFileChangeRequests = new HashSet<TestingCardFileChangeRequest>();
            this.TestingCards = new HashSet<TestingCard>();
            this.People = new HashSet<Person>();
            this.PersonChangeRequests = new HashSet<PersonChangeRequest>();
            this.CompaniesAccreditation = new HashSet<Company>();
            this.CompaniesLogo = new HashSet<Company>();
        }
    
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    
        public virtual ICollection<PersonHistory> PersonHistories { get; set; }
        public virtual ICollection<TestingCardFileChangeRequest> TestingCardFileChangeRequests { get; set; }
        public virtual ICollection<TestingCard> TestingCards { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<PersonChangeRequest> PersonChangeRequests { get; set; }
        public virtual ICollection<Company> CompaniesAccreditation { get; set; }
        public virtual ICollection<Company> CompaniesLogo { get; set; }
    }
}
