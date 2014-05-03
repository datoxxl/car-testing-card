using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestCard.Domain;
using TestCard.Web.Controllers;

namespace TestCard.Web.Models
{
    public class FilterQuery
    {
        public string Query { get; set; }

        public FilterQuery()
        {

        }

        public FilterQuery(string query)
        {
            Query = query.Replace("{CompanyID}", (HttpContext.Current.Session["CurrentUser"] as User).CompanyID.ToString());
        }

        public static implicit operator FilterQuery(string value)
        {
            return new FilterQuery(value);
        }

        public static implicit operator string(FilterQuery value)
        {
            return value.Query;
        }

        public override string ToString()
        {
            return Query;
        }
    }
}