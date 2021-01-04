using QuoteRating.Models;

namespace QuoteRating.RatingEngine
{
    public interface IQuoteService
    {
        Quote GetQuote(Inputs inputs);
    }
}
