using System.Collections.Generic;
using QuoteRating.Models.Factors;

namespace QuoteRating.Repositories
{
    public interface IRepository
    {
        IEnumerable<StateFactor> GetStateFactors();
        IEnumerable<BusinessFactor> GetBusinessFactors();
    }
}
