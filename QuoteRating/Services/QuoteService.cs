using QuoteRating.Models;

namespace QuoteRating.RatingEngine
{
    public class QuoteService : IQuoteService
    {
        public Quote GetQuote(Inputs inputs)
        {
            return new Quote
            {
                Premium = 6.78
            };
        }
    }
}