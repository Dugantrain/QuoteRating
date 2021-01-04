using System.Collections.Generic;
using QuoteRating.Models.Factors;

namespace QuoteRating.Repositories
{
    public class InMemoryRepository : IRepository
    {
        public IEnumerable<StateFactor> GetStateFactors()
        {
            var stateFactors = new List<StateFactor>
            {
                new StateFactor {State = "OH", Factor = 1},
                new StateFactor {State = "FL", Factor = 1.2},
                new StateFactor {State = "TX", Factor = .943}
            };
            return stateFactors;
        }

        public IEnumerable<BusinessFactor> GetBusinessFactors()
        {
            var businessFactors = new List<BusinessFactor>
            {
                new BusinessFactor {Business = "Architect", Factor = 1},
                new BusinessFactor {Business = "Plumber", Factor = 0.5},
                new BusinessFactor {Business = "Programmer", Factor = 1.25}
            };
            return businessFactors;
        }
    }
}