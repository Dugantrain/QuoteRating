using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuoteRating.Models;
using QuoteRating.Persistence;
using QuoteRating.RatingEngine;

namespace QuoteRating.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly ILogger<QuoteController> _logger;
        private readonly IQuoteService _quoteService;

        public QuoteController(ILogger<QuoteController> logger, IQuoteService quoteService)
        {
            _logger = logger;
            _quoteService = quoteService;
        }

        [HttpPost]
        public Quote Post(Inputs inputs)
        {
            return _quoteService.GetQuote(inputs);
        }
    }
}
