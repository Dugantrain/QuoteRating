using System;
using System.Linq;
using QuoteRating.Models;
using QuoteRating.RatingEngine;
using QuoteRating.Repositories;

namespace QuoteRating.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IRepository _repository;
        public QuoteService(IRepository repository)
        {
            _repository = repository;
        }
        public Quote GetQuote(Inputs inputs)
        {
            var stateFactor = 1D;
            var businessFactor = 1D;
            const int hazardFactor = 4;
            var basePremium = Math.Ceiling(inputs.Revenue / 1000);


            var allStateFactors = _repository.GetStateFactors();
            var allBusinessFactors = _repository.GetBusinessFactors();

            var matchingStateFactor =
                allStateFactors.FirstOrDefault(
                    s => s.State.ToLower().Equals(inputs.State.ToLower()));
            if (matchingStateFactor != null)
            {
                stateFactor = matchingStateFactor.Factor;
            }

            var matchingBusinessFactor =
                allBusinessFactors.FirstOrDefault(
                    b => b.Business.ToLower().Equals(inputs.Business.ToLower()));
            if (matchingBusinessFactor != null)
            {
                businessFactor = matchingBusinessFactor.Factor;
            }

            if (stateFactor <= 0) stateFactor = 1;
            if (businessFactor <= 0) businessFactor = 1;

            var premium = stateFactor * businessFactor * hazardFactor * basePremium;


            return new Quote
            {
                Premium = premium
            };
        }
    }
}