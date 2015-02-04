using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestCard.Domain.Services
{
    public class PersonStatisticService : DomainServiceBase<PersonStatistic>
    {
        public PersonStatisticService(PersonInfo currentUser)
            : base(currentUser) { }

        public void Recalculate()
        {
            var personList = new PersonService(this).GetAll(true).ToList();

            foreach (var item in personList)
            {
                var stat = new PersonStatistic();

                stat.PersonID = item.PersonID;

                var totalCount = _DbContext.TestingCards
                    .Where(x => x.ResponsiblePersonID == item.PersonID)
                    .Count();

                stat.FilledCardCnt = totalCount;

                stat.FirstTestingCnt = _DbContext.TestingCards
                    .Where(x => x.ResponsiblePersonID == item.PersonID
                        && x.IsFirstTesting == true)
                    .Count();

                stat.SecondaryTestingCnt = totalCount - stat.FirstTestingCnt;

                stat.ValidCardCnt = _DbContext.TestingCards
                    .Where(x => x.ResponsiblePersonID == item.PersonID
                        && x.IsValid == true)
                    .Count();

                stat.InvalidCardCnt = totalCount - stat.ValidCardCnt;

                stat.TestingCardDailyAvg = (decimal?)_DbContext.TestingCards
                    .Where(x => x.ResponsiblePersonID == item.PersonID)
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
                    .Where(x => x.ResponsiblePersonID == item.PersonID)
                    .Count();

                stat.ScheduleChangeRequestCnt =
                    _DbContext.PersonScheduleChangeRequests
                    .Where(x => x.ResponsiblePersonID == item.PersonID)
                    .Count();

                stat.UserOnlineTime =
                    _DbContext.PersonSessions
                    .Where(x => x.PersonID == item.PersonID)
                    .DefaultIfEmpty()
                    .Sum(x => x.Duration);

                stat.CreateDate = DateTime.Now;

                var oldRecord = this.Get(item.PersonID);

                if (oldRecord != null)
                {
                    this.Delete(oldRecord);
                }

                this.Add(stat);
            }

            this.SaveChanges();
        }

        public override IQueryable<PersonStatistic> GetAll(Helpers.DataFilterOption option, bool secureObject = false)
        {
            return base.GetAll(option, secureObject).Include(x => x.Person.Company);
        }

        public override IQueryable<PersonStatistic> SecurityFilter(IQueryable<PersonStatistic> query)
        {
            switch (_CurrentUser.AccountType)
            {
                case AccountTypes.Administrator:
                    break;
                case AccountTypes.QualityManager:
                    query = query.Where(x => x.Person.CompanyID == _CurrentUser.CompanyID);
                    break;
                case AccountTypes.Operator:
                    query = query.Where(x => x.PersonID == _CurrentUser.PersonID);
                    break;
                default:
                    break;
            }

            return base.SecurityFilter(query);
        }
    }
}
