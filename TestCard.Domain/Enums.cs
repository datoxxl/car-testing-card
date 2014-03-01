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
}
