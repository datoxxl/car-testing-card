using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCard.Domain
{
    public enum ConfirmStatuses : int { Approved = 1, Rejected = 2 }
    public enum AccountTypes : int { Administrator = 1, QualityManager = 2, Operator = 3 }
    public enum CodeTypes : int { TestingCardNumber = 1, TestingCardOrderNumber = 2 }
    
    [Flags]
    public enum Permissions : int
    {
        None = 0,
        View = 1,
        Add = 2,
        Edit = 4,
        Delete = 8
    }

    public enum Objects : int
    {
        Other = 0,
        Company = 1,
        Person = 2,
        PersonSchedule = 3,
        TestingCard = 4,
        PersonChangeRequest = 5,
        PersonScheduleChangeRequest = 6,
        TestingCardChangeRequest = 7,
        Statistics = 8
    }
}
