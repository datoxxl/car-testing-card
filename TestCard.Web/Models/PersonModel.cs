using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Models
{
    public class PersonModel
    {
        public RegisterModel UserInfo { get; set; }
        public PersonScheduleModel Schedule { get; set; } 
    }
}