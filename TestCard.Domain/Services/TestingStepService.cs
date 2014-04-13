using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Properties;
using System.Data.Entity;

namespace TestCard.Domain.Services
{
    public class TestingStepService : DomainServiceBase<TestingStep>
    {
        public List<TestingStep> GetAll(bool includeSubSteps)
        {
            return _DbContext.TestingSteps
                .Include(x => x.TestingSubSteps)
                .ToList();
        }
    }
}
