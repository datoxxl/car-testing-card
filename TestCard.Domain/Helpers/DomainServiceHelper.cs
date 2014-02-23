using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace TestCard.Domain.Helpers
{
    public static class DataFilterHelper
    {
        public static IQueryable<T> SortAndFilter<T>(this IQueryable<T> dbSet, DataFilterOption option)
            where T : class
        {
            if (!string.IsNullOrEmpty(option.SortByExpression))
            {
                dbSet = dbSet.OrderBy(string.Format("{0}", option.SortByExpression));
            }

            if (!string.IsNullOrEmpty(option.FilterExpression))
            {
                dbSet = dbSet.Where(option.FilterExpression, option.FilterParams);
            }

            option.TotalRowCount = dbSet.Count();
            return dbSet.Skip(option.StartRowIndex).Take(option.MaximumRows);
        }
    }

    public class DataFilterOption
    {
        public int MaximumRows { get; set; }
        public int StartRowIndex
        {
            get
            {
                return (PageIndex - 1) * MaximumRows;
            }
        }
        public int TotalRowCount { get; set; }
        public string SortByExpression { get; set; }
        public string FilterExpression { get; set; } /*Where Clause*/
        public object[] FilterParams { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get { return (int)Math.Ceiling(TotalRowCount / (double)MaximumRows); } }
        public List<Tuple<string, string, string, string>> ExtraFilter { set; get; }
    }
}
