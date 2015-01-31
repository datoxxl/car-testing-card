using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TestCard.Domain;
using TestCard.Domain.Services;

namespace TestCard.Web.Security
{
    public static class AppAuth
    {
        private const string CurrentUserKey = "CurrentUser";
        private const string SessionIDKey = "__SessionID";

        public static PersonInfo CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session == null)
                {
                    return null;
                }

                return (HttpContext.Current.Session[CurrentUserKey] as PersonInfo);
            }
            set
            {
                HttpContext.Current.Session[CurrentUserKey] = value;
            }
        }

        public static Guid? SessionID
        {
            get
            {
                if (HttpContext.Current.Session == null)
                {
                    return null;
                }

                return (HttpContext.Current.Session[SessionIDKey] as Guid?);
            }
            set
            {
                HttpContext.Current.Session[SessionIDKey] = value;
            }
        }

        public static bool Login(string idNumber, string password)
        {
            using (var service = new PersonService())
            {
                var per = service.Login(idNumber, password);

                if (per != null)
                {
                    var authTicket = new FormsAuthenticationTicket(1, idNumber,
                        DateTime.Now, DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes), true, per.PersonID.ToString());

                    string cookieContents = FormsAuthentication.Encrypt(authTicket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                    {
                        Expires = authTicket.Expiration,
                        Path = FormsAuthentication.FormsCookiePath
                    };

                    HttpContext.Current.Response.Cookies.Add(cookie);

                    StartSession(per);

                    return true;
                }
            }

            return false;
        }

        private static void StartSession(PersonInfo per)
        {
            //Set person as user in the session
            CurrentUser = per;
            SessionID = Guid.NewGuid();

            LogSessionStart();
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }

        public static void LogSessionStart()
        {
            if (CurrentUser != null
                && SessionID != null)
            {
                using (var service = new PersonSessionService())
                {
                    service.StartSession(
                        CurrentUser.PersonID,
                        SessionID.Value,
                        DateTime.Now);
                }
            }
        }

        public static void LogSessionEnd(HttpSessionState session)
        {
            var user = session[CurrentUserKey] as PersonInfo;
            var sessionID = (Guid?)session[SessionIDKey];

            if (user != null
                && sessionID != null)
            {
                using (var service = new PersonSessionService())
                {
                    service.EndSession(
                        user.PersonID,
                        sessionID.Value,
                        DateTime.Now);
                }

                session.Abandon();
            }
        }

        public static void LogSession()
        {
            if (CurrentUser != null
                && SessionID != null)
            {
                using (var service = new PersonSessionService())
                {
                    service.UpdateSession(
                        CurrentUser.PersonID,
                        SessionID.Value,
                        DateTime.Now);
                }
            }
        }
    }
}