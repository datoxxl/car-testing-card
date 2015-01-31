using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCard.Domain.Services
{
    public class PersonSessionService : DomainServiceBase<PersonSession>
    {
        public void StartSession(int personID, Guid sessionID, DateTime sessionStart)
        {
            var session = new PersonSession();

            session.PersonID = personID;
            session.SessionID = sessionID;
            session.SessionStart = sessionStart;
            session.LastSeenOn = sessionStart;
            session.CreateDate = DateTime.Now;

            var sessionNumber = this.GetAll()
                .Where(x => x.PersonID == personID)
                .Select(x => x.SessionNumber)
                .DefaultIfEmpty()
                .Max();

            session.SessionNumber = sessionNumber + 1;

            this.Add(session);

            this.SaveChanges();
        }

        public void UpdateSession(int personID, Guid sessionID, DateTime lastSeenOn)
        {
            var session = this.GetAll()
                           .FirstOrDefault(x => x.PersonID == personID && x.SessionID == sessionID);

            if (session == null)
            {
                return;
            }

            session.LastSeenOn = lastSeenOn;

            this.Update(session);
            this.SaveChanges();
        }

        public void EndSession(int personID, Guid sessionID, DateTime sessionEnd)
        {
            var session = this.GetAll()
                .FirstOrDefault(x => x.PersonID == personID && x.SessionID == sessionID);

            if (session == null)
            {
                return;
            }

            session.SessionEnd = sessionEnd;

            this.Update(session);
            this.SaveChanges();
        }
    }
}
