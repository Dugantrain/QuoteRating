using System.Collections.Generic;
using QuoteRating.Models.Factors;

namespace QuoteRating.Persistence
{
    public interface IPersistence
    {
        IEnumerable<StateFactor> GetStateFactors();
        IEnumerable<BusinessFactor> GetBusinessFactors();
    }

    public class JsonPersistence : IPersistence
    {
        public IEnumerable<StateFactor> GetStateFactors()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BusinessFactor> GetBusinessFactors()
        {
            throw new System.NotImplementedException();
        }
    }
}
