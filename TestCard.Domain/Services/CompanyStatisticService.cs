using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestCard.Domain.Services
{
    public class CompanyStatisticService : DomainServiceBase<CompanyStatistic>
    {
        public CompanyStatisticService(PersonInfo currentUser)
            : base(currentUser) { }

        public void Recalculate()
        {
            var companyList = new CompanyService(this).GetAll(true).ToList();

            foreach (var item in companyList)
            {
                var stat = new CompanyStatistic();

                stat.CompanyID = item.CompanyID;

                var totalCount = _DbContext.TestingCards
                    .Include(x => x.Person)
                    .Where(x => x.Person.CompanyID == item.CompanyID)
                    .Count();

                stat.FilledCardCnt = totalCount;

                stat.FirstTestingCnt = _DbContext.TestingCards
                    .Include(x => x.Person)
                    .Where(x => x.Person.CompanyID == item.CompanyID
                        && x.IsFirstTesting == true)
                    .Count();

                stat.SecondaryTestingCnt = totalCount - stat.FirstTestingCnt;

                stat.ValidCardCnt = _DbContext.TestingCards
                    .Include(x => x.Person)
                    .Where(x => x.Person.CompanyID == item.CompanyID
                        && x.IsValid == true)
                    .Count();

                stat.InvalidCardCnt = totalCount - stat.ValidCardCnt;

                stat.TestingCardDailyAvg = (decimal?)_DbContext.TestingCards
                    .Include(x => x.Person)
                    .Where(x => x.Person.CompanyID == item.CompanyID)
                    .GroupBy(x => new
                    {
                        x.EffectiveDate.Value.Year,
                        x.EffectiveDate.Value.Month,
                        x.EffectiveDate.Value.Day
                    })
                    .Select(x => x.Count())
                    .DefaultIfEmpty()
                    .Average(x => x);

                stat.TestingCardChangeRequestCnt =
                    _DbContext.TestingCardChangeRequests
                    .Include(x => x.ResponsiblePerson)
                    .Where(x => x.ResponsiblePerson.CompanyID == item.CompanyID)
                    .Count();

                stat.ScheduleChangeRequestCnt =
                    _DbContext.PersonScheduleChangeRequests
                    .Include(x => x.ResponsiblePerson)
                    .Where(x => x.ResponsiblePerson.CompanyID == item.CompanyID)
                    .Count();

                stat.UserOnlineTime =
                    _DbContext.PersonSessions
                    .Include(x => x.Person)
                    .Where(x => x.Person.CompanyID == item.CompanyID)
                    .DefaultIfEmpty()
                    .Sum(x => x.Duration);

                stat.CreateDate = DateTime.Now;

                var oldRecord = this.Get(item.CompanyID);

                if (oldRecord != null)
                {
                    this.Delete(oldRecord);
                }

                this.Add(stat);
            }

            this.SaveChanges();
        }

        public override IQueryable<CompanyStatistic> GetAll(Helpers.DataFilterOption option, bool secureObject = false)
        {
            return base.GetAll(option, secureObject).Include(x => x.Company);
        }

        public override IQueryable<CompanyStatistic> SecurityFilter(IQueryable<CompanyStatistic> query)
        {
            switch (_CurrentUser.AccountType)
            {
                case AccountTypes.Administrator:
                    break;
                case AccountTypes.QualityManager:
                    query = query.Where(x => x.CompanyID == _CurrentUser.CompanyID);
                    break;
                case AccountTypes.Operator:
                    query = new List<CompanyStatistic>().AsQueryable();
                    break;
                default:
                    break;
            }

            return base.SecurityFilter(query);
        }
    }
}
