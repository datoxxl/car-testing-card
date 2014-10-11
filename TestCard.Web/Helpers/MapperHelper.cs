using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCard.Web.Helpers
{
    public static class MapperHelper
    {
        public static AutoMapper.IMappingExpression<ICollection<Domain.TestingCardDetail>, List<Models.TestingStep>>
            ConstructTestingCardDetails(this AutoMapper.IMappingExpression<ICollection<Domain.TestingCardDetail>, List<Models.TestingStep>> expression)
        {
            return expression.ConstructUsing((ICollection<Domain.TestingCardDetail> srcList) =>
                {
                    List<Models.TestingStep> steps = GetMappedTestingSteps();

                    var subSteps = steps.SelectMany(x => x.TestingSubSteps);

                    foreach (var item in srcList)
                    {
                        var dest = subSteps.FirstOrDefault(x => x.TestingSubStepID == item.TestingSubStepID);

                        AutoMapper.Mapper.Map(item, dest);
                    }

                    return steps;
                });
        }

        public static AutoMapper.IMappingExpression<ICollection<Domain.TestingCardDetailChangeRequest>, List<Models.TestingStep>>
            ConstructTestingCardDetails(this AutoMapper.IMappingExpression<ICollection<Domain.TestingCardDetailChangeRequest>, List<Models.TestingStep>> expression)
        {
            return expression.ConstructUsing((ICollection<Domain.TestingCardDetailChangeRequest> srcList) =>
            {
                List<Models.TestingStep> steps = GetMappedTestingSteps();

                var subSteps = steps.SelectMany(x => x.TestingSubSteps);

                foreach (var item in srcList)
                {
                    var dest = subSteps.FirstOrDefault(x => x.TestingSubStepID == item.TestingSubStepID);

                    AutoMapper.Mapper.Map(item, dest);
                }

                return steps;
            });
        }

        private static List<Models.TestingStep> GetMappedTestingSteps()
        {
            using (var service = new TestCard.Domain.Services.TestingStepService())
            {
                return AutoMapper.Mapper.Map<List<Models.TestingStep>>(service.GetAll(true));
            }
        }
    }
}