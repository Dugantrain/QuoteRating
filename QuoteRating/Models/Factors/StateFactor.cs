using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteRating.Models.Factors
{
    public class StateFactor : IFactor
    {
        public string State { get; set; }
        public double Factor { get; set; }
    }
}
