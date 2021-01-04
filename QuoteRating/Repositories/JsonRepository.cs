using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using QuoteRating.Models.Factors;

namespace QuoteRating.Repositories
{
    public class JsonRepository : IRepository
    {
        public IEnumerable<StateFactor> GetStateFactors()
        {
            var directory = Directory.GetCurrentDirectory();
            return JsonConvert.DeserializeObject<IEnumerable<StateFactor>>(
                File.ReadAllText(directory + "/Repositories/state-factors.json"));
        }

        public IEnumerable<BusinessFactor> GetBusinessFactors()
        {
            var directory = Directory.GetCurrentDirectory();
            return JsonConvert.DeserializeObject<IEnumerable<BusinessFactor>>(
                File.ReadAllText(directory + "/Repositories/business-factors.json"));
        }
    }
}